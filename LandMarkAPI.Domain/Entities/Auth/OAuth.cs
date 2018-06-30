using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Domain.Models.OAuth;

namespace LandMarkAPI.Domain.Entities.Auth
{
    public class OAuth : OAuthToken
	{
		[Key]
	    public int OAuthId { get; set; }
    }
}
