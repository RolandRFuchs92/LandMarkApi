using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Data;
using LandMarkAPI.Domain.Models.OAuth;

namespace LandMarkApi.Repository
{
    public class OAuthRepo
    {
	    private readonly LandMarkContext _db;

		public OAuthRepo()
	    {
			_db = new LandMarkContextFactory().CreateDbContext();
		}

		public OAuthToken GetOAuthToken(string identityNameRef)
	    {
			//ToDo: come and update this too
			return (from o in _db.OAuths
					join p in _db.Persons on o.OAuthId equals p.OAuthId
					where p.Email == identityNameRef
					select o).FirstOrDefault();
	    }
    }
}
