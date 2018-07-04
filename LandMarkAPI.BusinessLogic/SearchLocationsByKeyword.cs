using System;
using System.Collections.Generic;
using System.Text;
using LandMarkAPI.Authentication;
using LandMarkAPI.Domain.Models.OAuth;

namespace LandMarkAPI.BusinessLogic
{
    public class SearchLocationsByKeyword
    {
	    private readonly OAuthParamsRequestToken _flickr;

	    public SearchLocationsByKeyword(OAuthParamsRequestToken flickr)
	    {
			var client = new OAuthClient(flickr).GetClient();
		}

		public string FindLocationByKeyword(string where)
	    {
		    var auth = new OAuthClient(_flickr).GetClient();
			

		    return "";
	    }
    }
}
