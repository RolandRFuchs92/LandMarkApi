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
		    var photoDetailsRaw = JsonConvert.DeserializeObject<PhotoContainer>(flickrResponse);
		    return new PhotoDetail
		    {
				FlickrPhotoId = photoDetailsRaw.photo.id,
				DateUploaded = null,//photoDetailsRaw.dateuploaded,
				Decription = photoDetailsRaw.photo.description._content,
				Title = photoDetailsRaw.photo.title._content,
				Farm =  photoDetailsRaw.photo.farm,
				IsFavorite =  photoDetailsRaw.photo.isfavorite,
				License =  photoDetailsRaw.photo.license,
				Media = photoDetailsRaw.photo.media,
				OriginalFormat = photoDetailsRaw.photo.originalformat,
				OriginalSecret = photoDetailsRaw.photo.originalsecret,
				Rotation = photoDetailsRaw.photo.rotation,
				Secret = photoDetailsRaw.photo.secret,
				Server = photoDetailsRaw.photo.server,
				Views = photoDetailsRaw.photo.views
		    };
	    }
    }
}
