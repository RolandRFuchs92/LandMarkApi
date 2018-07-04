using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Text;
using LandMarkApi.Repository;
using LandMarkAPI.Authentication;
using LandMarkAPI.Domain.Models.OAuth;
using OAuth;

namespace LandMarkAPI.BusinessLogic
{
    public class SearchLocationsByKeyword
    {
	    private readonly OAuthParamsRequestToken _flickr;
	    private readonly OAuthRequest _client;


	    public SearchLocationsByKeyword(OAuthParamsRequestToken flickr, string idRef)
	    {
		    var oauth = new OAuthRepo().GetOAuthToken(idRef);
		    _client = new OAuthClient(flickr).GetClient();
		    _client.Token = oauth.Token;
		    _client.TokenSecret = oauth.TokenSecret;
		    _client.RequestUrl = "https://api.flickr.com/serices/rest";
	    }

		public string FindLocationByKeyword(string where)
		{
			var queryMethod = "method=flickr.places.find";
			var query = $"&query={where}";
			var url = $"{_client.RequestUrl}?{queryMethod}&{query}&{_client.GetAuthorizationQuery()}";

		    var request = (HttpWebRequest)WebRequest.Create(url);
		    var response = (HttpWebResponse)request.GetResponse();
		    var data = "";


			return "";
	    }
    }
}
