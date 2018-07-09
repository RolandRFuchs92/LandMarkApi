using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandMarkApi.Repository.Interfaces;
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
	    private readonly IImageRepo _imageRepo;
	    private readonly IPlaceRepo _placeRepo;
	    private OAuthParamsRequestToken _flickr;

	    public ListLocationsController(IConfiguration config, IImageRepo imageRepo, IPlaceRepo placeRepo)
	    {
		    _config = config;
		    _imageRepo = imageRepo;
		    _placeRepo = placeRepo;
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
		    var search = new SearchLocationsByKeyword(_flickr, _placeRepo);
		    return search.FindLocationByKeyword(where);
		}

	    private Dictionary<string, string> ListPhotosByLonLat(string place_id)
	    {
			return new GetPhotosListForLocation(_flickr, _imageRepo).GetImageList(place_id);
		}
	}
}
