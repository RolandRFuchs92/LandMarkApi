using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LandMarkApi.Controllers
{
    public class ListLocationsController : Controller
    {
	    public List<int> ListLocations(string where)
	    {
		    var user = this.User;

		    return new List<int>();
	    }
    }
}
