using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Channels;
using LandMarkAPI.Data;
using LandMarkAPI.Domain.Entities.Auth;
using LandMarkAPI.Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;

namespace LandMarkApi.Repository
{
	public class PersonRepo
	{
		private readonly LandMarkContext _db;

		public PersonRepo()
		{
			///TODO: use the correct implementation of a factory.
			_db = new LandMarkContextFactory().CreateDbContext();
		}
		public bool SavePersonFromQueryString(string successResponse)
		{
			try
			{
				var parseResponse = ParseSuccessResponse(successResponse);
				var oauth = ParseSuccessDictionaryToOAuth(parseResponse);
				var person = ParseSuccessDictionaryToPerson(parseResponse);

				_db.OAuths.Add(oauth);
				_db.SaveChanges();

				_db.Persons.Add(person);
				person.OAuthId = oauth.OAuthId;
				_db.SaveChanges();

				return true;
			}
			catch (Exception e)
			{
				//Log error to db pl0x;
				return false;
			}

		}

		private OAuth ParseSuccessDictionaryToOAuth(Dictionary<string, string> successResp)
		{
			return new OAuth
			{
				Token		= successResp["oauth_token"],
				TokenSecret = successResp["oauth_token_secret"],
			};
		}

		private Person ParseSuccessDictionaryToPerson(Dictionary<string,string> successResp)
		{
			var fullName = successResp["fullname"].Split("%20");

			return new Person
			{
				Name = fullName[0],
				Surname = fullName[fullName.Length-1],
				Username = successResp["username"],
				Usernsid = successResp["user_nsid"]
			};
		}

		private Dictionary<string, string> ParseSuccessResponse(string successResponse)
		{
			return successResponse
				.Split('&')
				.ToDictionary(
					key => key.Split('=')[0], 
					val => val.Split('=')[1]
					);
		}
	}
}