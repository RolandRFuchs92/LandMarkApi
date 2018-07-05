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

	    public List<int> ListLocations(string where)
	    {
		    where = "durban";
		    var idref = this.User.Claims.Select(i => i.Value).FirstOrDefault();
		    var moo = new SearchLocationsByKeyword(_flickr, idref);
		    var doo = moo.FindLocationByKeyword(where);

			return new List<int>();
	    }
    }
}
