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

namespace LandMarkAPI.BusinessLogic.Flickr
{
    public class GetPhotoDetails
    {
		private readonly OAuthParamsRequestToken _flickr;
	    private readonly IPhotoDetailRepo _photoDetailRepo;

	    public GetPhotoDetails(OAuthParamsRequestToken flickr, IPhotoDetailRepo _photoDetailRepo)
	    {
		    _flickr = flickr;
		    this._photoDetailRepo = _photoDetailRepo;
	    }

	    public PhotoDetail GetDetails(long flickrPhotoId)
	    {
		    return RequestPhotoDetails(flickrPhotoId);
	    }

	    private PhotoDetail RequestPhotoDetails(long flickrPhotoId)
	    {
		    var method = "flickr.photos.getInfo";
		    var paramDictionary = new Dictionary<string, string>
		    {
			    { "photo_id", flickrPhotoId.ToString() }
		    };
		    var url = new UrlBuilder(_flickr).BuildRequestUrl(method, paramDictionary);

		    var request = (HttpWebRequest)WebRequest.Create(url);
		    var response = (HttpWebResponse)request.GetResponse();

		    using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
		    {
			    var dataString = reader.ReadToEnd();
			    var data = dataString.IndexOf($"\"stat\":\"fail\"") > 0
				    ? new PhotoDetail()
				    : new ParseFlickrResponse().ParsePhotoDetails(dataString);

			    _photoDetailRepo.SaveImageDetails(data);
			    return new Translate().GetPhotoDetail(flickrPhotoId, _photoDetailRepo);
		    }

	    }

	}
}
