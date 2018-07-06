using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Domain.DTO.Recieve;
using LandMarkAPI.Domain.Entities.Flickr;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace LandMarkAPI.BusinessLogic.Flickr
{
    public class ParseFlickrResponse
    {
	    public List<Place> ParseFlickrJsonResponse(string flickrResponse)
	    {
		    return JsonConvert.DeserializeObject<Location>(flickrResponse).places.place;
	    }

	    public List<Photo> ParsePhotoJson(string flickrResponse)
	    {
		    return JsonConvert.DeserializeObject<Photos>(flickrResponse).photos.Photo;
	    }

	    public PhotoDetail ParsePhotoDetails(string flickrResponse)
	    {
			return new PhotoDetail();
	    }
    }
}
