using System;
using System.Collections.Generic;
using System.Linq;
using LandMarkAPI.Data;
using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkApi.Repository.Flickr
{
    public class ImageRepo
    {
		private readonly LandMarkContext _db;

	    public ImageRepo()
	    {
		    _db = new LandMarkContextFactory().CreateDbContext();
	    }

	    public bool SaveImageList(List<Photo> photos)
	    {
		    try
		    {
			    _db.Photos.AddRange(photos);
			    _db.SaveChanges();

			    return true;
		    }
		    catch (Exception e)
		    {
			    return false;
		    }
	    }

	    public List<Photo> GetAllImages()
	    {
		    return _db.Photos.ToList();
	    }

	    public Photo GetImageById(long photoId)
	    {
		    return _db.Photos.FirstOrDefault(i => i.PhotoId == photoId);
	    }
	}
}
