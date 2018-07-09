namespace LandMarkApi.Repository.Interfaces
{
	public interface IPersonRepo
	{
		bool SavePersonFromQueryString(string successResponse, string identityNameRef);
	}
}