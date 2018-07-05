using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Data;

namespace LandMarkApi.Repository
{
    public class ImageRepo
    {
		private readonly LandMarkContext _db;

	    public ImageRepo()
	    {
		    _db = new LandMarkContextFactory().CreateDbContext();
	    }

	}
}
