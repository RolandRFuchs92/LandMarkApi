using System.Collections.Generic;
using System.Linq;
using LandMarkApi.Repository;
using LandMarkApi.Repository.Interfaces;
using LandMarkAPI.Authentication;
using LandMarkAPI.Authentication.Utils;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace LandMarkApi.Controllers
{
	public class FlickrAuthController : Controller
	{
		private IConfiguration _iConfiguration;
		private readonly IPersonRepo _personRepo;
		private readonly OAuthParamsRequestToken _flickr;
		private static List<OAuthToken> _tokens = new List<OAuthToken>();

		public FlickrAuthController(IConfiguration iConfiguration, IPersonRepo personRepo)
		{
			_iConfiguration = iConfiguration;
			_personRepo = personRepo;
			_flickr = new OAuthParamsRequestToken(iConfiguration);
		}

		/// <summary>
		/// First redirect to the test page
		/// </summary>
		/// <returns></returns>
		public IActionResult LinkAccount()
		{
			var token = new RequestOAuthToken(_flickr).GetRequestToken();
			_tokens.Add(token);

			var redirectUrl = new ParseResponse().GetRedirectUrl(token, _flickr);
			return Redirect(redirectUrl);
		}

		/// <summary>
		/// OAuthVerifier callback controller to hand incoming redirect from the client after app auth
		/// </summary>
		/// <returns></returns>
		public IActionResult OAuthVerifier(string successResp)
		{
			var token = new ParseResponse().ParseAuthResponse(Request.QueryString.ToString());
			token = CollectUserToken(token);
			var successResponse = new AuthorizationToken(_flickr).GetUserAfterAuth(token);

			if (_personRepo.SavePersonFromQueryString(successResponse, "moo@moo.com"))
				ViewData["Message"] = "Your account has been linked!";
			else
				ViewData["Message"] = "There was an error linking your account.";

			return View();
		}

		/// <summary>
		/// Get the clients Token details 
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		private OAuthToken CollectUserToken(OAuthToken token)
		{
			return (from t in _tokens
					where t.Token == token.Token
					select new OAuthToken
					{
						Token = t.Token,
						TokenSecret = t.TokenSecret,
						Verifier = token.Verifier
					}).FirstOrDefault();
		}
	}
}	