using System.Collections.Generic;
using System.Linq;
using LandMarkAPI.Domain.Models.OAuth;

namespace LandMarkAPI.Authentication.Utils
{
    public class ParseResponse
    {
		/// <summary>
		/// Parse the confirmation string into a dictionary
		/// </summary>
		/// <param name="responseText"></param>
		/// <returns></returns>
	    public Dictionary<string,string> ParseTokenConfirmationReponse(string responseText)
	    {
		    return responseText.Split('&').ToDictionary(key => key.Split('=')[0], val => val.Split('=')[1]);
	    }

		/// <summary>
		/// Once we have a dictionary, we can pass it into an OAuthToken
		/// </summary>
		/// <param name="parsedReponse"></param>
		/// <returns></returns>
	    public OAuthToken ParseDictToToken(Dictionary<string, string> parsedReponse)
	    {
		    return new OAuthToken
		    {
			    Token = parsedReponse["oauth_token"],
			    TokenSecret = parsedReponse["oauth_token_secret"]
		    };
	    }

	    public string GetRedirectUrl(OAuthToken token, OAuthParamsRequestToken flickr)
	    {
		    var redirParts = new[]
		    {
				flickr.AuthorizeUrl,
				$"{flickr.RequestToken.Token}={token.Token}",
		    };

		    return string.Join("?",redirParts);
	    }

	    public OAuthToken ParseAuthResponse(string queryString)
	    {
		    var dic = queryString.Split("&").Select(i => i.Split("=")).ToArray();
		    return new OAuthToken
		    {
				Token = dic[0][1].ToString(),
				Verifier =  dic[1][1].ToString()
			};
	    }
    }
}
