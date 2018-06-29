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

        public IActionResult Index()
        {
	        var moo = new OAuthAccess(_flickr).GetRequestToken();
			return View();
        }
    }
}