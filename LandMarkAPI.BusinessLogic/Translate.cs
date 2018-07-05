using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkApi.Repository;
using LandMarkApi.Repository.Flickr;

namespace LandMarkAPI.BusinessLogic
{
    public class Translate
    {
	    public Dictionary<string, string> GetPlaceDictionary()
	    {
			return new PlaceRepo().GetAllPlaces().ToDictionary(key => key.place_id, val => val._content);
	    }
    }
}
