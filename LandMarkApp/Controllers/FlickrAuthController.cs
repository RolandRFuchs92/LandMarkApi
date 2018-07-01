using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OAuth;
using LandMarkAPI.Authentication;
using LandMarkAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Caching.Memory;

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace LandMarkApp.Controllers
{
	public class FlickrAuthController : Controller
	{
		private IConfiguration _iConfiguration;
		private OAuthParamsRequestToken _flickr;
		private IMemoryCache _cache;
		private static List<OAuthToken> _tokens = new List<OAuthToken>();

		public FlickrAuthController(IConfiguration iConfiguration, IMemoryCache memoryCache)
		{
			_iConfiguration = iConfiguration;
			_flickr = new OAuthParamsRequestToken(iConfiguration);
			_cache = memoryCache;
		}

		/// <summary>
		/// First redirect to the test page
		/// </summary>
		/// <returns></returns>
		public IActionResult BrowseLandmarks()
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
		public IActionResult OAuthVerifier()
		{
			var token = new ParseResponse().ParseAuthResponse(Request.QueryString.ToString());
			token = CollectUserToken(token);
			var queryString = new AuthorizationToken(_flickr).GetUserAfterAuth(token);

			return View(new { message = queryString });
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult SaveFakePerson()
		{
			var queryString = "fullname=Jamal%20Fanaian&oauth_token=72157626318069415-087bfc7b5816092c&oauth_token_secret=a202d1f853ec69de&user_nsid=21207597%40N07&username=jamalfanaian";

			var isSuccess = new LandMarkApi.Repository.PersonRepo().SavePersonFromQueryString(queryString);

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