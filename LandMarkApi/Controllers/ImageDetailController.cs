using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandMarkApi.Repository.Interfaces;
using LandMarkAPI.BusinessLogic.Flickr;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LandMarkApi.Controllers
{
    public class ImageDetailController : Controller
    {
	    private readonly IPhotoDetailRepo _photoDetailRepo;
	    private OAuthParamsRequestToken _flickr;

	    public ImageDetailController(IConfiguration config, IPhotoDetailRepo photoDetailRepo)
	    {
		    _photoDetailRepo = photoDetailRepo;
		    _flickr = new OAuthParamsRequestToken(config);
	    }

		public IActionResult GetImageDetail(long flickrPhotoId)
		{
			var imageDetails = new GetPhotoDetails(_flickr, _photoDetailRepo).GetDetails(flickrPhotoId);

			return Ok(imageDetails);
	    }
    }
}