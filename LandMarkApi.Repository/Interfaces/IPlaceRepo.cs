using System.Collections.Generic;
using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkApi.Repository.Interfaces
{
	public interface IPlaceRepo
	{
		List<Place> GetAllPlaces();
		Place GetPlaceById(string placeId);
		bool SavePlaceList(List<Place> places);
	}
}