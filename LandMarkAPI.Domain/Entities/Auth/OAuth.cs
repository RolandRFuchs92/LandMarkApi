using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Domain.Models.OAuth;

namespace LandMarkAPI.Domain.Entities.Auth
{
    public class OAuth
    {
	    public int OAuthId { get; set; }
	    public OAuthToken OAuthToken { get; set; }
    }
}
/*
fullname=Jamal%20Fanaian
&oauth_token=72157626318069415-087bfc7b5816092c
&oauth_token_secret=a202d1f853ec69de
&user_nsid=21207597%40N07
&username=jamalfanaian
 */
