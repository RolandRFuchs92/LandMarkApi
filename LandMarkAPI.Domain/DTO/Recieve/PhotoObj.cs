using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkAPI.Domain.DTO.Recieve
{
	public class Photos
	{
		public PhotoObj photos { get; set; }
		public string stat { get; set; }
	}

    public class PhotoObj
    {
	    public int page { get; set; }
	    public int pages { get; set; }
	    public int perpage { get; set; }
	    public int total { get; set; }
	    public List<Photo> Photo { get; set; }

    }
}
