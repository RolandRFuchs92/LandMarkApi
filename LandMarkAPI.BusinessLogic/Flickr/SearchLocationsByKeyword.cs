using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using LandMarkApi.Repository;
using LandMarkAPI.Authentication;
using LandMarkAPI.Authentication.Utils;
using LandMarkAPI.BusinessLogic.Flickr;
using LandMarkAPI.Domain.Entities.Flickr;
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
		    _flickr = flickr;
		    var oauth = new OAuthRepo().GetOAuthToken(idRef);
		    _client = new OAuthClient(flickr).GetClient();
		    _client.Token = oauth.Token;
		    _client.TokenSecret = oauth.TokenSecret;
		    _client.RequestUrl = "https://api.flickr.com/services/rest";
		    _client.CallbackUrl = null;
		    _client.SignatureMethod = OAuthSignatureMethod.PlainText;
	    }

		public Dictionary<string, string> FindLocationByKeyword(string where)
		{
			//var url = "method=flickr.places.find&api_key=5eba472ef777bf46f17a03c62590fe6c&query=new+zealand&format=json&nojsoncallback=1";
			var method = "flickr.places.find";
			var paramDictionary = new Dictionary<string, string> {{ "query", where}};
			var url = BuildRequestUrl(method, paramDictionary);

			var request = (HttpWebRequest)WebRequest.Create(url);
		    var response = (HttpWebResponse)request.GetResponse();

			using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
			{
				var data = new ParseFlickrResponse().ParseFlickrJsonResponse(reader.ReadToEnd());
				
				return
			}
	    }
		
	    private string BuildRequestUrl(string method, Dictionary<string, string> paramDictionary)
	    {
		    var paramList = (from q in paramDictionary
								select $"{q.Key}={q.Value}");

		    var paramString = string.Join("&", paramList);
		    var baseURL = "https://api.flickr.com/services/rest/?";
		    var additionalParams = "&per_page=10&format=json&nojsoncallback=1";


			return $"{baseURL}method={method}&api_key={_flickr.ConsumerKey}&{paramString}{additionalParams}";
	    }
    }
}
