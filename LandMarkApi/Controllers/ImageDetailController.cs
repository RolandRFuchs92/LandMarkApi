using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LandMarkApi.Controllers
{
    public class ImageDetailController : Controller
    {
	    public IActionResult GetImageDetail(long ImageId)
	    {
			var imageDetails = new 

			return new JsonResult(new {});
	    }
    }
}