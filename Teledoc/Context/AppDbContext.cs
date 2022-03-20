using Microsoft.EntityFrameworkCore;
using Teledoc.Models;

namespace Teledoc.Context
{
	public class AppDbContext : DbContext
	{
		public DbSet<Client> Clients { get; set; } = null!;
		public DbSet<Founder> Founders { get; set; } = null!;
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			//Database.EnsureDeleted();
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			Client client1 = new () { Id = 1, Inn = 839791482733, Name = "ИП Машкова", Type = "ИП", AddDate = new DateTime(2022, 03, 01), UpdateDate = new DateTime(2022, 03, 01) };
			Client client2 = new () { Id = 2, Inn = 659526288085, Name = "ООО МосДачТрест", Type = "ЮЛ", AddDate = new DateTime(2022, 03, 01), UpdateDate = new DateTime(2022, 03, 01) };
			Client client3 = new () { Id = 3, Inn = 802600922607, Name = "ООО НордПолис", Type = "ЮЛ", AddDate = new DateTime(2022, 03, 01), UpdateDate = new DateTime(2022, 03, 01) };
			
			modelBuilder.Entity<Client>().HasData(
				client1,
				client2,
				client3
			);

			modelBuilder.Entity<Founder>().HasData(
				new Founder { Id = 1, Inn = 814668806323, Fio = "Иванов Пётр Сергеевич", AddDate = new DateTime(2022, 03, 01), UpdateDate = new DateTime(2022, 03, 01), ClientId = 2},
				new Founder { Id = 2, Inn = 219698970300, Fio = "Симонюк Лидия Александровна", AddDate = new DateTime(2022, 03, 01), UpdateDate = new DateTime(2022, 03, 01), ClientId = 2 },
				new Founder { Id = 3, Inn = 416547389156, Fio = "Петров Владимир Владимирович", AddDate = new DateTime(2022, 03, 01), UpdateDate = new DateTime(2022, 03, 01), ClientId = 3 },
				new Founder { Id = 4, Inn = 987897320535, Fio = "Пыхалов Никита Олегович", AddDate = new DateTime(2022, 03, 01), UpdateDate = new DateTime(2022, 03, 01), ClientId = 3 },
				new Founder { Id = 5, Inn = 903986524612, Fio = "Забродина Элина Викторовна", AddDate = new DateTime(2022, 03, 01), UpdateDate = new DateTime(2022, 03, 01), ClientId = 3 }
			);
		}
	}
}
