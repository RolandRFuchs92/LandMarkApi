using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace LandMarkAPI.Domain.Models.OAuth
{
	public class OAuthParamsRequestToken
	{
		public OAuthParamsRequestToken(IConfiguration iConfiguration)
		{
			var data = iConfiguration.GetSection("Flickr").GetChildren().ToDictionary(k => k.Key, v=> v.Value);
			ConsumerKey = data["ConsumerKey"];
			ConsumerSecret = data["ConsumerSecret"];
			RequestUrl = data["RequestUrl"];
			Version = data["Version"];
			RequestTokenUrl = $"{RequestUrl}/{data["RequestToken"]}";
			AuthorizeUrl = $"{RequestUrl}/{data["Authorize"]}";
			AccessTokenUrl = $"{RequestUrl}/{data["AccessToken"]}";
		}

		public string ConsumerKey { get; }
		public string ConsumerSecret { get; }
		public string RequestUrl { get; }
		public string RequestTokenUrl { get; set; }
		public string AuthorizeUrl { get; set; }
		public string AccessTokenUrl { get; set; }
		public string Version { get; }
	}
}
