using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.Design;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OAuth;
using LandMarkAPI.Authentication;
using LandMarkAPI.Domain.Models;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;


namespace LandMarkApp.Controllers
{
    public class FlickrAuthController : Controller
    {
	    private IConfiguration _iConfiguration;
	    private OAuthParamsRequestToken _flickr;

	    public FlickrAuthController(IConfiguration iConfiguration)
	    {
		    _iConfiguration = iConfiguration;
		    _flickr = new OAuthParamsRequestToken(iConfiguration);
	    }

	    public IActionResult BrowseLandmarks()
	    {
		    var token = new RequestOAuthToken(_flickr).GetRequestToken();
		    var redirectUrl = new ParseResponse().GetRedirectUrl(token, _flickr);

			return Redirect(redirectUrl);
		}

	    public IActionResult OAuthVerifier(string resp)
	    {
		    return Json(new {message = "Yay!"});
	    }

        public IActionResult Index()
        {
			return View();
        }
    }
}