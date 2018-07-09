using LandMarkAPI.Domain.Entities.Flickr;

namespace LandMarkApi.Repository.Interfaces
{
	public interface IPhotoDetailRepo
	{
		PhotoDetail GetPhotoDetail(long photoId);
		bool SaveImageDetails(PhotoDetail photoDetail);
	}
}