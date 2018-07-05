using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkAPI.Domain.DTO.Recieve
{
	public class Location
	{
		public PlacesObj places { get; set; }
		public string stat { get; set; }
	}

    public class PlacesObj
    {
	    public List<Place> place { get; set; }
	    public string query { get; set; }
	    public int total { get; set; }

    }
}
