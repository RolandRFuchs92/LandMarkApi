﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkApi.Repository.Interfaces;
using LandMarkAPI.Data;
using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkApi.Repository.Flickr
{
    public class PhotoDetailRepo : IPhotoDetailRepo
	{
		private readonly LandMarkContext _db;

	    public PhotoDetailRepo(LandMarkContext db)
	    {
		    _db = db;
	    }

	    public bool SaveImageDetails(PhotoDetail photoDetail)
	    {
		    try
		    {
			    _db.PhotoDetails.Add(photoDetail);
			    _db.SaveChanges();

			    return true;
		    }
		    catch (Exception e)
		    {
			    return false;
		    }
	    }

	    public PhotoDetail GetPhotoDetail(long photoId)
	    {
		    return _db.PhotoDetails.FirstOrDefault(i => i.FlickrPhotoId == photoId);
	    }

	}
}
