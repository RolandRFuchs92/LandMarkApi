using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandMarkAPI.Domain.Entities.Flickr
{
    public class Photo
    {
		[Key]
	    public int PhotoId { get; set; }
	    public long id { get; set; }
	    public string owner { get; set; }
	    public string secret { get; set; }
	    public int server { get; set; }
	    public int farm { get; set; }
	    public string title { get; set; }
	    public bool ispublic { get; set; }
	    public bool isfriend { get; set; }
	    public bool isfamily { get; set; }
    }
}
