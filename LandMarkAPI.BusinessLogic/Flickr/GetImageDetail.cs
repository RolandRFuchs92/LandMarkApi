using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LandMarkApi.Repository;
using LandMarkApi.Repository.Flickr;
using LandMarkAPI.Domain.Entities.Flickr;
using LandMarkAPI.Domain.Models.OAuth;

namespace LandMarkAPI.BusinessLogic.Flickr
{
    public class GetImageDetail
    {
		private readonly OAuthParamsRequestToken _flickr;

	    public GetImageDetail(OAuthParamsRequestToken flickr)
	    {
		    _flickr = flickr;
	    }

	    public Dictionary<string, string> GetImageList(string locationId)
	    {
		    var location = new PhotoDetailRepo().GetPlaceById(locationId);
		    var lat = location.latitude.ToString().Replace(",", ".");
		    var lon = location.longitude.ToString().Replace(",", ".");

		    return GetImageListByLatLon(lat, lon);
	    }

	    private Dictionary<string, string> GetImageListByLatLon(long photo_id)
	    {
		    var method = "flickr.photos.search";
		    var paramDictionary = new Dictionary<string, string>
		    {
			    { "lat", photo_id.ToString() }
		    };
		    var url = new UrlBuilder(_flickr).BuildRequestUrl(method, paramDictionary);

		    var request = (HttpWebRequest)WebRequest.Create(url);
		    var response = (HttpWebResponse)request.GetResponse();

		    using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
		    {
			    var dataString = reader.ReadToEnd();
			    var data = dataString.IndexOf($"\"stat\":\"fail\"") > 0
				    ? new PhotoDetail()
				    : new ParseFlickrResponse().ParsePhotoDetails(dataString);//running out of time, but would use dynamic type setter

			    new PhotoDetailRepo().SaveImageDetails(data);
			    return new Translate().GetPhotoDictionary();
		    }

	    }

	}
}
