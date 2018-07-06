using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Data;
using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkApi.Repository.Flickr
{
    public class PhotoDetailRepo
    {
		private readonly LandMarkContext _db;

	    public PhotoDetailRepo()
	    {
		    _db = new LandMarkContextFactory().CreateDbContext();
	    }

	    public bool SaveImageDetails(PhotoDetail photoDetail)
	    {
		    return false;
	    }

	}
}
