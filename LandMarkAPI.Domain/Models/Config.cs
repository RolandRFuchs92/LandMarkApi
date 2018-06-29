using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Domain.Models.OAuth;

namespace LandMarkAPI.Domain.Models
{
    public class Config
    {
		public string Logging { get; set; }
	    public OAuthParamsRequestToken Flickr { get; set; }
	}
}
