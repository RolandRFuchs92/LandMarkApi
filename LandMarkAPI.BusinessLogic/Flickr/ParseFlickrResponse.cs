using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Domain.DTO.Recieve;
using LandMarkAPI.Domain.Entities.Flickr;
using MsgPack.Serialization;
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
		    var photoDetailsRaw = JsonConvert.DeserializeObject<PhotoDetailObj>(flickrResponse);
		    return new PhotoDetail
		    {
				FlickrPhotoId = photoDetailsRaw.id,
				DateUploaded = null,//photoDetailsRaw.dateuploaded,
				Decription = photoDetailsRaw.description._content,
				Title = photoDetailsRaw.title._content,
				Farm =  photoDetailsRaw.farm,
				IsFavorite =  photoDetailsRaw.isfavorite,
				License =  photoDetailsRaw.license,
				Media = photoDetailsRaw.media,
				OriginalFormat = photoDetailsRaw.originalformat,
				OriginalSecret = photoDetailsRaw.originalsecret,
				Rotation = photoDetailsRaw.rotation,
				Secret = photoDetailsRaw.secret,
				Server = photoDetailsRaw.server,
				Views = photoDetailsRaw.views
		    };
	    }
    }
}
