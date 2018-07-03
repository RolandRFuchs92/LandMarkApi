using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LandMarkAPI.Domain.Entities.Auth;
using LandMarkAPI.Domain.Entities.Person;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LandMarkAPI.Data
{
    public class LandMarkContext : IdentityDbContext
    {
	    public LandMarkContext(DbContextOptions<LandMarkContext> options) : base(options){}

		public DbSet<Person> Persons { get; set; }
	    public DbSet<OAuth> OAuths { get; set; }
    }
}
