using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkApi.Repository;
using LandMarkApi.Repository.Flickr;
using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkAPI.BusinessLogic
{
    public class Translate
    {
	    public Dictionary<string, string> GetPlaceDictionary()
	    {
			return new PlaceRepo().GetAllPlaces().ToDictionary(key => key.place_id, val => val._content);
	    }

	    public Dictionary<string, string> GetPhotoDictionary()
	    {
			return new ImageRepo().GetAllImages().ToDictionary(key => key.id.ToString(), val => BuildImageUrlRef(val));
		}

	    private string BuildImageUrlRef(Photo photo)
	    {
		    var baseUrl = $"https://farm{photo.farm}.staticflickr.com";
		    return $"{baseUrl}/{photo.server}/{photo.id}_{photo.secret}.jpg";
	    }
    }
}
