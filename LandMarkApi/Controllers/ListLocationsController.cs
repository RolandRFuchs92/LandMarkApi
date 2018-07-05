using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandMarkAPI.BusinessLogic;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LandMarkApi.Controllers
{
    public class ListLocationsController : Controller
    {
	    private readonly IConfiguration _config;
	    private OAuthParamsRequestToken _flickr;

	    public ListLocationsController(IConfiguration config)
	    {
		    _config = config;
		    _flickr = new OAuthParamsRequestToken(config);
		}

	    public IActionResult KeyowrdPartial(string where)
	    {
		    return PartialView("_KeywordResult", ListLocations(where));
	    }

	    public IActionResult GetKeywordResult()
	    {
		    return PartialView("_KeywordResult");
	    }

	    public IActionResult GetImageList()
	    {
		    return "";
	    }

	    public Dictionary<string, string> SearchLocationsBYKeyword(string where)
	    {
		    return ListLocations(where);
	    }

	    private Dictionary<string, string> ListLocations(string where)
	    {
		    var idref = this.User.Claims.Select(i => i.Value).FirstOrDefault();
		    var search = new SearchLocationsByKeyword(_flickr, idref);

		    return search.FindLocationByKeyword(where);
		}
	}
}
