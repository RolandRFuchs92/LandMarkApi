using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandMarkAPI.Domain.Entities.Flickr
{
    public class Place
    {
	    public string place_id { get; set; }
	    public string woeid { get; set; }
	    public double latitude { get; set; }
	    public double longitude { get; set; }
	    public string place_url { get; set; }
	    public string place_type { get; set; }
	    public string place_type_id { get; set; }
	    public string timezone { get; set; }
	    public string _content { get; set; }
	    public string woe_name { get; set; }
    }
}
