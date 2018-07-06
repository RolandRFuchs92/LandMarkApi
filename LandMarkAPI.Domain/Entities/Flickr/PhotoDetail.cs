using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandMarkAPI.Domain.Entities.Flickr
{
    public class PhotoDetail
    {
	    [Key]
	    public int PhotoDetailId { get; set; }
	    public long FlickrPhotoId{ get; set; }
	    public string Secret { get; set; }
	    public int Server { get; set; }
	    public int Farm { get; set; }
	    public DateTime? DateUploaded { get; set; }
	    public bool IsFavorite { get; set; }
	    public int License { get; set; }
	    public int Rotation { get; set; }
		public string OriginalSecret { get; set; }
	    public string OriginalFormat { get; set; }
	    public int Views { get; set; }
	    public string Title { get; set; }
	    public string Decription { get; set; }
	    public string Media { get; set; }
	}
}
