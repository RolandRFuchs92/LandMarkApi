using System.Collections.Generic;
using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkApi.Repository.Interfaces
{
	public interface IImageRepo
	{
		List<Photo> GetAllImages();
		Photo GetImageById(long photoId);
		bool SaveImageList(List<Photo> photos);
	}
}