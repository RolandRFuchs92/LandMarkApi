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
			var flickrBody = iConfiguration.GetSection("Flickr");
			var data = flickrBody
				.GetChildren()
				.ToDictionary(k => k.Key, v => v.Value);
			var reqToken = ParseTokenBody(flickrBody, "RequestTokenResponse");
			var authToken = ParseTokenBody(flickrBody, "AuthorizationTokenResponse");

			ConsumerKey = data["ConsumerKey"];
			ConsumerSecret = data["ConsumerSecret"];
			RequestUrl = data["RequestUrl"];
			Version = data["Version"];
			RequestTokenUrl = $"{RequestUrl}/{data["RequestToken"]}";
			AuthorizeUrl = $"{RequestUrl}/{data["Authorize"]}";
			AccessTokenUrl = $"{RequestUrl}/{data["AccessToken"]}";
			RequestToken = InitTokenResponse(reqToken);
			AuthorizationToken = InitTokenResponse(authToken);
		}

		public string ConsumerKey { get; }
		public string ConsumerSecret { get; }
		public string RequestUrl { get; }
		public string RequestTokenUrl { get;  }
		public string AuthorizeUrl { get; }
		public string AccessTokenUrl { get;  }
		public string Version { get; }
		public TokenResponse RequestToken { get; }
		public TokenResponse AuthorizationToken { get; }

		private Dictionary<string, string> ParseTokenBody(IConfigurationSection configurationSection, string section)
		{
			return configurationSection.GetSection(section)
				.GetChildren()
				.ToDictionary(key => key.Key, val => val.Value);
		}

		private TokenResponse InitTokenResponse(Dictionary<string, string> token)
		{
			return new TokenResponse(token["Token"], token["Secret"]);
		}
	}
}
