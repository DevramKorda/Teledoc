using Microsoft.EntityFrameworkCore;

namespace Teledoc.Context
{
	public static class AppDbContextBuilder
	{
		public static DbContextOptionsBuilder<AppDbContext> optionsBuilder = new();
		public static string connectionString = @"Server=(localdb)\mssqllocaldb;Database=Teledocdb;Trusted_Connection=True;";

		static AppDbContextBuilder()
		{	
			optionsBuilder.UseSqlServer(connectionString);
		}
	}
}
