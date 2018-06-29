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
		/// <summary>
		/// Constructor gets the its inforormation from appsettings(after being parsed)
		/// </summary>
		/// <param name="flickr"></param>
		public OAuthAccess(OAuthParamsRequestToken flickr)
		{
			_flickr = flickr;
		}

		/// <summary>
		/// Gets a populated OAuthToken
		/// </summary>
		/// <returns></returns>
		public OAuthToken GetRequestToken()
		{
			var auth = GetClient().GetAuthorizationQuery();
			var moo = GetAuthResponse(auth);

			return new OAuthToken();
		}

		/// <summary>
		/// Get the client using the OAuthRequest Api
		/// </summary>
		/// <returns>The initial request client.</returns>
		private OAuthRequest GetClient()
		{
			var client = new OAuthRequest
			{
				Method = "GET",
				SignatureMethod = OAuthSignatureMethod.HmacSha1,
				ConsumerKey = _flickr.ConsumerKey,
				ConsumerSecret = _flickr.ConsumerSecret,
				RequestUrl = _flickr.RequestTokenUrl,
				SignatureTreatment = OAuthSignatureTreatment.Unescaped,
				CallbackUrl = "rol@rol.com"
			};

			return client;
		}

		/// <summary>
		/// The a token key and secret with Auth query string
		/// </summary>
		/// <param name="auth"></param>
		/// <returns></returns>
		private OAuthToken GetAuthResponse(string auth)
		{
			var url = GetClient().RequestUrl + "?" + auth;
			var request = (HttpWebRequest)WebRequest.Create(url);
			var response = (HttpWebResponse)request.GetResponse();
			var token = new OAuthToken();

			WebHeaderCollection header = response.Headers;

			var encoding = ASCIIEncoding.ASCII;
			using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
			{
				var tokenParser = new ParseResponse();
				var parsedResponse = tokenParser.ParseTokenConfirmationReponse(reader.ReadToEnd());
				if (parsedResponse["oauth_callback_confirmed"].Any())
					tokenParser.ParseDictToToken(parsedResponse);
			}

			return token;
		}

		
	}
}
