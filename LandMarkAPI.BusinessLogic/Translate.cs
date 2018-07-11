using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkApi.Repository;
using LandMarkApi.Repository.Flickr;
using LandMarkApi.Repository.Interfaces;
using LandMarkAPI.BusinessLogic.Flickr;
using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkAPI.BusinessLogic
{
	public class Translate
	{
		public Dictionary<string, string> GetPlaceDictionary(IPlaceRepo placeRepo)
		{
			var list = placeRepo.GetAllPlaces().Select(i => new { i.place_id, i._content }).Distinct();
			return list.ToDictionary(key => key.place_id, val => val._content);
		}

		public Dictionary<string, string> GetPhotoDictionary(IImageRepo imageRepo)
		{
			var list = (from image in imageRepo.GetAllImages().ToList()
						group image by new
						{
							image.id
						} into grp
						select grp.First()).ToDictionary(i=> i.id.ToString(), k => BuildImageUrlRef(k));

			return list;
		}

		public PhotoDetail GetPhotoDetail(long flickrPhotoId, IPhotoDetailRepo photoDetailRepo)
		{
			return photoDetailRepo.GetPhotoDetail(flickrPhotoId);
		}

		private string BuildImageUrlRef(Photo photo)
		{
			var baseUrl = $"https://farm{photo.farm}.staticflickr.com";
			return $"{baseUrl}/{photo.server}/{photo.id}_{photo.secret}.jpg";
		}
	}
}
