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

	    public IActionResult BrowseLandmarks()
	    {
		    var token = new RequestOAuthToken(_flickr).GetRequestToken();
			_tokens.Add(token);

			var redirectUrl = new ParseResponse().GetRedirectUrl(token, _flickr);
			return Redirect(redirectUrl);
		}

	    public IActionResult OAuthVerifier()
	    {
		    var token = new ParseResponse().ParseAuthResponse(Request.QueryString.ToString());
		    token = CollectUserToken(token);
			var queryString = new AuthorizationToken(_flickr).GetUserAfterAuth(token);

			return View(new {message = queryString });	
	    }

        public IActionResult Index()
        {
			return View();
        }

	    private OAuthToken CollectUserToken(OAuthToken token)
	    {
		    return (from t in _tokens
			    where t.Token == token.Token
			    select new OAuthToken
			    {
					Token = t.Token,
					TokenSecret =  t.TokenSecret,
					Verifier = token.Verifier
			    }).FirstOrDefault();
	    }
    }
}