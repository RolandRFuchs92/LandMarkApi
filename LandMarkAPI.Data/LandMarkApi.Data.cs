using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LandMarkAPI.Data
{
	public class LandMarkContextFactory : IDesignTimeDbContextFactory<LandMarkContext>
	{
		public LandMarkContext CreateDbContext(string[] args)
		{
				var optionsBuilder = new DbContextOptionsBuilder<LandMarkContext>();
				optionsBuilder.UseSqlServer("server=MSI\\SQLEXPRESS;Database=LandMarkDb;Integrated Security=true;MultipleActiveResultSets=true;");

				return new LandMarkContext(optionsBuilder.Options);
		}
	}
}