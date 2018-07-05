using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LandMarkApi.Repository.Flickr;
using LandMarkAPI.Domain.Entities.Flickr;
using LandMarkAPI.Domain.Models.OAuth;
using Microsoft.EntityFrameworkCore.Storage;

namespace LandMarkAPI.BusinessLogic.Flickr
{
    public class GetImageListForLocation
    {
	    private OAuthParamsRequestToken _flickr;

	    public GetImageListForLocation(OAuthParamsRequestToken flickr, string idRef)
		{
			_flickr = flickr;
		}

	    public Dictionary<string, string> GetImageList(int lon, int lat)
	    {
		    var method = "flickr.photos.geo.photosForLocation";
		    var paramDictionary = new Dictionary<string, string>
		    {
			    { "lat", lat.ToString() },
			    { "lon", lon.ToString() }
		    };
		    var url = new UrlBuilder(_flickr).BuildRequestUrl(method, paramDictionary);

		    var request = (HttpWebRequest)WebRequest.Create(url);
		    var response = (HttpWebResponse)request.GetResponse();

		    using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
		    {
			    var dataString = reader.ReadToEnd();
			    var data = dataString.IndexOf($"\"stat\":\"fail\"") > 0
				    ? new List<Place>()
				    : new ParseFlickrResponse().ParseFlickrJsonResponse(dataString);

			    new PlaceRepo().SavePlaceList(data);
			    return new Translate().GetPlaceDictionary();
			}
	    }
	}
}
