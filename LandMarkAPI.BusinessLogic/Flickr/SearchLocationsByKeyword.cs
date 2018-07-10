using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using LandMarkApi.Repository;
using LandMarkApi.Repository.Flickr;
using LandMarkApi.Repository.Interfaces;
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
	    private readonly IPlaceRepo _placeRepo;

	    public SearchLocationsByKeyword(OAuthParamsRequestToken flickr, IPlaceRepo placeRepo)
	    {
		    _flickr = flickr;
			_placeRepo = placeRepo;
	    }

		public Dictionary<string, string> FindLocationByKeyword(string where)
		{
			var method = "flickr.places.find";
			var paramDictionary = new Dictionary<string, string> {{ "query", where}};
			var url = new UrlBuilder(_flickr).BuildRequestUrl(method, paramDictionary);

			var request = (HttpWebRequest)WebRequest.Create(url);
		    var response = (HttpWebResponse)request.GetResponse();

			using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
			{
				var dataString = reader.ReadToEnd();
				var data = dataString.IndexOf($"\"stat\":\"fail\"") > 0 
					?  new List<Place>()
					: new ParseFlickrResponse().ParseFlickrJsonResponse(dataString);

				_placeRepo.SavePlaceList(data);
				return new Translate().GetPlaceDictionary(_placeRepo);
			}
	    }
		
	  
    }
}
