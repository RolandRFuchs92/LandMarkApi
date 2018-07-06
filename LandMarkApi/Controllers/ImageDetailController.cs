using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandMarkAPI.BusinessLogic.Flickr;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LandMarkApi.Controllers
{
    public class ImageDetailController : Controller
    {
	    private OAuthParamsRequestToken _flickr;

	    public ImageDetailController(IConfiguration config)
	    {
		    _flickr = new OAuthParamsRequestToken(config);
	    }


		public IActionResult GetImageDetail(long flickrPhotoId)
		{
			var imageDetails = new GetPhotoDetails(_flickr).GetDetails(flickrPhotoId);

			return new JsonResult(imageDetails);
	    }
    }
}