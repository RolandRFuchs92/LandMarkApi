using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.Extensions.Options;
using OAuth;
using TinyOAuth1;

namespace LandMarkAPI.Authentication
{
	public class RequestOAuthToken
	{
		private readonly OAuthClient _client;

		/// <summary>
		/// Constructor gets the its inforormation from appsettings(after being parsed)
		/// </summary>
		/// <param name="flickr"></param>
		public RequestOAuthToken(OAuthParamsRequestToken flickr)
		{
			_client = new OAuthClient(flickr);
		}

		/// <summary>
		/// Gets a populated OAuthToken
		/// </summary>
		/// <returns></returns>
		public OAuthToken GetRequestToken()
		{
			return GetAuthResponse();
		}

		/// <summary>
		/// The a token key and secret with Auth query string
		/// </summary>
		/// <param name="auth"></param>
		/// <returns></returns>
		private OAuthToken GetAuthResponse()
		{
			var client = _client.GetClient();
			var auth = client.GetAuthorizationQuery();
			var url = client.RequestUrl + "?" + auth;
			var request = (HttpWebRequest)WebRequest.Create(url);
			var response = (HttpWebResponse)request.GetResponse();
			var token = new OAuthToken();

			WebHeaderCollection header = response.Headers;

			var encoding = ASCIIEncoding.ASCII;
			using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
			{
				var tokenParser = new ParseResponse();
				var parsedResponse = tokenParser.ParseTokenConfirmationReponse(reader.ReadToEnd());
				if (parsedResponse["oauth_callback_confirmed"].Any())
					token = tokenParser.ParseDictToToken(parsedResponse);
			}

			return token;
		}
	}
}
