using System.ComponentModel.DataAnnotations;

namespace LandMarkAPI.Domain.Entities.Person
{
    public class User
    {
		[Key]
	    public int UserId { get; set; }
	    public string UserName { get; set; }
	    public string UserSurname { get; set; }
	    public string UserUsername { get; set; }
	    public string Usernsid { get; set; }
	    public int OAuthId { get; set; }
    }
}
