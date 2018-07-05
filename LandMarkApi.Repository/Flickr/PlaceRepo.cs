using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Data;
using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkApi.Repository.Flickr
{
    public class PlaceRepo
    {
	    private readonly LandMarkContext _db;

	    public PlaceRepo()
	    {
			_db = new LandMarkContextFactory().CreateDbContext();
		}
	    public bool SavePlaceList(List<Place> places)
	    {
		    try
		    {
			    _db.Places.AddRange(places);
			    _db.SaveChanges();

			    return true;
		    }
		    catch (Exception e)
		    {
			    return false;
		    }
	    }

	    public List<Place> GetAllPlaces()
	    {
		    return _db.Places.ToList();
	    }

	    public Place GetPlaceById(string placeId)
	    {
		    return _db.Places.FirstOrDefault(i => i.place_id == placeId);
	    }

    }
}
