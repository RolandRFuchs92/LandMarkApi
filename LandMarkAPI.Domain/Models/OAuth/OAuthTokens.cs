using System;
using System.Collections.Generic;
using System.Text;

namespace LandMarkAPI.Domain.Models.OAuth
{
    public class OAuthTokens
    {
	    public string Token { get; set; }
	    public string TokenSecret { get; set; }
	    public string Verifier { get; set; }
	    public string Signature { get; set; }
    }
}
