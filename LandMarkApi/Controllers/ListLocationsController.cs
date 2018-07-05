﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandMarkAPI.BusinessLogic;
using LandMarkAPI.BusinessLogic.Flickr;
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

	    public IActionResult GetImageList(string locationId)
	    {
		    return Json( ListPhotosByLonLat(locationId) );
	    }

	    public Dictionary<string, string> GetImageListByLocationId(string place_id)
	    {
		    return ListPhotosByLonLat(place_id);
	    }

		public Dictionary<string, string> SearchLocationsBYKeyword(string where)
	    {
		    return ListLocations(where);
	    }

	    private Dictionary<string, string> ListLocations(string where)
	    {
		    var search = new SearchLocationsByKeyword(_flickr);
		    return search.FindLocationByKeyword(where);
		}

	    private Dictionary<string, string> ListPhotosByLonLat(string place_id)
	    {
			return new GetImageListForLocation(_flickr).GetImageList(place_id);
		}
	}
}
