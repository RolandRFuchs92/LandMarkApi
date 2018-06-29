using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.Extensions.Options;
using OAuth;
using TinyOAuth1;

namespace LandMarkAPI.Authentication
{
	public class OAuthAccess
	{
		private readonly OAuthParamsRequestToken _flickr;

		public OAuthAccess(OAuthParamsRequestToken flickr)
		{
			_flickr = flickr;
		}


		public OAuthTokens GetRequestToken()
		{
			var client = GetClient();
			client.CallbackUrl = "ro@ro.co";
			var auth = client.GetAuthorizationQuery();

			var moo = GetAuthResponse(auth);

			return new OAuthTokens();
		}

		private OAuthRequest GetClient(bool addCallbackUrl = false)
		{
			var client = new OAuthRequest
			{
				Method = "GET",
				SignatureMethod = OAuthSignatureMethod.HmacSha1,
				ConsumerKey = _flickr.ConsumerKey,
				ConsumerSecret = _flickr.ConsumerSecret,
				RequestUrl = _flickr.RequestTokenUrl,
				SignatureTreatment = OAuthSignatureTreatment.Unescaped,

			};

			client.CallbackUrl = addCallbackUrl ? "rol@rol.com" : null;

			return client;
		}

		private string GetAuthResponse(string auth)
		{
			var url = GetClient(true).RequestUrl + "?" + auth;
			var request = (HttpWebRequest)WebRequest.Create(url);
			var response = (HttpWebResponse)request.GetResponse();

			WebHeaderCollection header = response.Headers;

			var encoding = ASCIIEncoding.ASCII;
			using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
			{
				string responseText = reader.ReadToEnd();
				//break down response and use next.
			}

			return "";
		}

	}
}
