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

	    public OAuthToken GetAuthToken()
	    {



		    return new OAuthToken();
	    }
	}
}
