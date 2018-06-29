using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandMarkAPI.Domain.Models.OAuth
{
    public class TokenResponse
    {
	    public TokenResponse(string token, string secret)
	    {
		    Token = token;
		    Secret = secret;
	    }
	    public string Token { get; }
	    public string Secret { get; }
    }
}
