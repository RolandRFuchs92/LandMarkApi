using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Domain.Models.OAuth;
using OAuth;

namespace LandMarkAPI.Authentication
{
    public class OAuthClient
    {
	    private readonly OAuthParamsRequestToken _flickr;

	    public OAuthClient(OAuthParamsRequestToken flickr)
	    {
		    _flickr = flickr;
	    }

	    /// <summary>
	    /// Get the client using the OAuthRequest Api
	    /// </summary>
	    /// <returns>The initial request client.</returns>
	    public OAuthRequest GetClient(bool isRequestToken = true)
	    {
		    var client = new OAuthRequest
		    {
			    Method = "GET",
			    SignatureMethod = OAuthSignatureMethod.HmacSha1,
			    ConsumerKey = _flickr.ConsumerKey,
			    ConsumerSecret = _flickr.ConsumerSecret,
			    RequestUrl = isRequestToken ?  _flickr.RequestTokenUrl : _flickr.AccessTokenUrl,
			    SignatureTreatment = OAuthSignatureTreatment.Unescaped,
				Type = isRequestToken? OAuthRequestType.RequestToken : OAuthRequestType.AccessToken,
			    CallbackUrl = isRequestToken ? "https://localhost:44301/FlickrAuth/OAuthVerifier" : null,
				Version = "1.0"
		    };

		    return client;
	    }
	}
}
