using System.Linq;
using System.Net;
using System.Text;
using LandMarkAPI.Domain.Models.OAuth;
using OAuth;

namespace LandMarkAPI.Authentication
{
    public class AuthorizationToken
    {
	    private readonly OAuthClient _client;

		public AuthorizationToken(OAuthParamsRequestToken flickr)
	    {
		    _client = new OAuthClient(flickr);
		}

		/// <summary>
		/// Get the authentication token from the client after we get their verifier
		/// </summary>
		/// <param name="token">Token from last request</param>
		/// <returns></returns>
	    public string GetUserAfterAuth(OAuthToken token)
		{
			var client = _client.GetClient(false);
		    client.Verifier = token.Verifier;
		    client.Token = token.Token;
			client.TokenSecret = token.TokenSecret;

		    return GetResponse(client); ;
	    }

		/// <summary>
		/// Get the response from flickr adter we have gotten their user data
		/// </summary>
		/// <param name="client"></param>
		/// <returns></returns>
	    public string GetResponse(OAuthRequest client)
		{ 
		    var url = client.RequestUrl + "?" + client.GetAuthorizationQuery();
		    var request = (HttpWebRequest)WebRequest.Create(url);
		    var response = (HttpWebResponse)request.GetResponse();
			var data = "";

		    WebHeaderCollection header = response.Headers;

		    var encoding = ASCIIEncoding.ASCII;
		    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
			    data = reader.ReadToEnd();

		    return data;
		}
	}
}
