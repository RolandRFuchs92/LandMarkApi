using LandMarkAPI.Domain.Models.OAuth;

namespace LandMarkApi.Repository.Interfaces
{
	public interface IOAuthRepo
	{
		OAuthToken GetOAuthToken(string identityNameRef);
	}
}