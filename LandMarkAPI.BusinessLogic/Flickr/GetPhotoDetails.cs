﻿using System;
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
    public class GetPhotoDetails
    {
		private readonly OAuthParamsRequestToken _flickr;

	    public GetPhotoDetails(OAuthParamsRequestToken flickr)
	    {
		    _flickr = flickr;
	    }

	    public PhotoDetail GetDetails(long FlickrPhotoId)
	    {
		    return RequestPhotoDetails(FlickrPhotoId);
	    }

	    private PhotoDetail RequestPhotoDetails(long FlickrPhotoId)
	    {
		    var method = "flickr.photos.search";
		    var paramDictionary = new Dictionary<string, string>
		    {
			    { "photo_id", FlickrPhotoId.ToString() }
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

			    new PhotoDetailRepo().SaveImageDetails(data);
			    return new Translate().GetPhotoDetail();
		    }

	    }

	}
}
