using Teledoc.Models;
using Teledoc.Context;
using Teledoc.Current;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Teledoc.Services
{
	public static class DataHandler
	{
		private static AppDbContext GetDb()
		{
			return new AppDbContext(AppDbContextBuilder.optionsBuilder.Options);
		}

		public static List<Client> GetClients()
		{
			List<Client> clients;
			using (AppDbContext db = GetDb())
			{
				clients = db.Clients.ToList();
			}
			return clients;
		}

		public static List<Founder> GetFounders()
		{
			List<Founder> founders;
			using (AppDbContext db = GetDb())
			{
				founders = db.Founders.Include(x => x.Client).ToList();
			}
			return founders;
		}

		public static Client GetClientDetails(int id)
		{
			Client client;
			using (AppDbContext db = GetDb())
			{
				client = db.Clients.Include(c => c.Founders).First<Client>(x => x.Id == id);
			}
			return client;
		}

		public static Founder GetFounderDetails(int id)
		{
			Founder founder;
			using (AppDbContext db = GetDb())
			{
				founder = db.Founders.Include(f => f.Client).First<Founder>(x => x.Id == id);
			}
			return founder;
		}

		public static void CreateClient(Client client)
		{
			client.Id = 0;
			client.AddDate = DateTime.Now;
			client.UpdateDate = client.AddDate;

			using (AppDbContext db = GetDb())
			{
				db.Clients.Add(client);
				db.SaveChanges();
			}
		}

		public static void CreateFounder(Founder founder)
		{
			founder.Id = 0;
			founder.AddDate = DateTime.Now;
			founder.UpdateDate = founder.AddDate;
			founder.ClientId = CurrentData.ClientId;

			using (AppDbContext db = GetDb())
			{
				db.Founders.Add(founder);
				db.SaveChanges();
			}
		}

		public static Client GetClient(int id)
		{
			Client client;
			using (AppDbContext db = GetDb())
			{
				client = db.Clients.First<Client>(x => x.Id == id);
			}
			return client;
		}

		public static void EditClient(Client client)
		{
			using(AppDbContext db = GetDb())
			{
				Client c = db.Clients.First<Client>(x => x.Id == client.Id);
				
				if(c != null)
				{
					c.Inn = client.Inn;
					c.Name = client.Name;
					c.Type = client.Type;
					c.UpdateDate = DateTime.Now;

					db.SaveChanges();
				}	
			}
		}

		public static Founder GetFounder(int id)
		{
			Founder founder;
			using (AppDbContext db = GetDb())
			{
				founder = db.Founders.First<Founder>(x => x.Id == id);
			}
			return founder;
		}

		public static void EditFounder(Founder founder)
		{
			using (AppDbContext db = GetDb())
			{
				Founder f = db.Founders.First<Founder>(x => x.Id == founder.Id);

				if (f != null)
				{
					f.Inn = founder.Inn;
					f.Fio = founder.Fio;					
					f.UpdateDate = DateTime.Now;

					db.SaveChanges();
				}
			}
		}
	}
}
