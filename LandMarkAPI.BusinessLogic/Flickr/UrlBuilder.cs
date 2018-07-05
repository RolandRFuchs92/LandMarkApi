using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LandMarkAPI.Domain.Models.OAuth;

namespace LandMarkAPI.BusinessLogic.Flickr
{
	public class UrlBuilder
	{
		private readonly OAuthParamsRequestToken _flickr;

		public UrlBuilder(OAuthParamsRequestToken flickr)
		{
			_flickr = flickr;
		}

		public string BuildRequestUrl(string method, Dictionary<string, string> paramDictionary)
		{
			var paramList = from q in paramDictionary
							select $"{q.Key}={q.Value}";

			var paramString = string.Join("&", paramList);
			var baseURL = "https://api.flickr.com/services/rest/?";
			var additionalParams = "&per_page=10&format=json&nojsoncallback=1";


			return $"{baseURL}method={method}&api_key={_flickr.ConsumerKey}&{paramString}{additionalParams}";
		}
	}
}
