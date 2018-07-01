using System.ComponentModel.DataAnnotations;

namespace LandMarkAPI.Domain.Entities.Person
{
    public class Person
    {
		[Key]
	    public int PersonId { get; set; }
	    public string Name { get; set; }
	    public string Surname { get; set; }
	    public string Username { get; set; }
	    public string Usernsid { get; set; }
	    public int OAuthId { get; set; }
    }
}
