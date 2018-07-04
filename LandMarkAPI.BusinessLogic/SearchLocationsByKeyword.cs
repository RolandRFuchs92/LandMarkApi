using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Claims;
using System.Text;
using LandMarkAPI.Authentication;
using LandMarkAPI.Domain.Models.OAuth;
using OAuth;

namespace LandMarkAPI.BusinessLogic
{
    public class SearchLocationsByKeyword
    {
	    private readonly OAuthParamsRequestToken _flickr;
	    private readonly OAuthRequest _client;


	    public SearchLocationsByKeyword(OAuthParamsRequestToken flickr)
	    {
		    _client = new OAuthClient(flickr).GetClient();
		}

		public string FindLocationByKeyword(string where)
		{
		    var auth = new OAuthClient(_flickr).GetClient();

		    var url = _client.RequestUrl + "?" + _client.GetAuthorizationQuery();
		    var request = (HttpWebRequest)WebRequest.Create(url);
		    var response = (HttpWebResponse)request.GetResponse();
		    var data = "";


			return "";
	    }
    }
}
