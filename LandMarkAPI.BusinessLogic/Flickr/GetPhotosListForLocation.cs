using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LandMarkApi.Repository;
using LandMarkApi.Repository.Flickr;
using LandMarkApi.Repository.Interfaces;
using LandMarkAPI.Domain.Entities.Flickr;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.EntityFrameworkCore.Storage;

namespace LandMarkAPI.BusinessLogic.Flickr
{
    public class GetPhotosListForLocation
    {
	    private readonly OAuthParamsRequestToken _flickr;
	    private readonly IImageRepo _imageRepo;
	    private readonly IPlaceRepo _placeRepo;

	    public GetPhotosListForLocation(OAuthParamsRequestToken flickr, IImageRepo imageRepo, IPlaceRepo placeRepo)
	    {
		    _flickr = flickr;
		    _imageRepo = imageRepo;
		    _placeRepo = placeRepo;
	    }

	    public Dictionary<string, string> GetImageList(string locationId)
	    {
		    var location = _placeRepo.GetPlaceById(locationId);
		    var lat = location.latitude.ToString().Replace(",",".");
		    var lon = location.longitude.ToString().Replace(",", ".");

		    return GetImageListByLatLon(lat, lon);
	    }

	    private Dictionary<string, string> GetImageListByLatLon(string lat, string lon)
	    {
		    var method = "flickr.photos.search";
		    var paramDictionary = new Dictionary<string, string>
		    {
			    { "lat", lat.ToString() },
			    { "lon", lon.ToString() },
			    { "per_page", "10" }
		    };
		    var url = new UrlBuilder(_flickr).BuildRequestUrl(method, paramDictionary);

		    var request = (HttpWebRequest)WebRequest.Create(url);
		    var response = (HttpWebResponse)request.GetResponse();

		    using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
		    {
			    var dataString = reader.ReadToEnd();
			    var data = dataString.IndexOf($"\"stat\":\"fail\"") > 0
				    ? new List<Photo>()
				    : new ParseFlickrResponse().ParsePhotoJson(dataString);//running out of time, but would use dynamic type setter

			    _imageRepo.SaveImageList(data);
			    return new Translate().GetPhotoDictionary(_imageRepo);
		    }

		}
	}
}
