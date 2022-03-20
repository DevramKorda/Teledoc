using Microsoft.AspNetCore.Mvc;
using Teledoc.Services;
using Teledoc.Models;
using Teledoc.Current;
using Teledoc.Controllers;

namespace Teledoc.Controllers
{
	public class ClientsController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View(DataHandler.GetClients());
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			return View(DataHandler.GetClientDetails(id));
		}

		[HttpGet]
		public IActionResult CreateClient()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateClient(Client client)
		{
			DataHandler.CreateClient(client);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult CreateFounder(int id)
		{
			CurrentData.ClientId = id;
			return View();
		}

		[HttpPost]
		public IActionResult CreateFounder(Founder founder)
		{
			DataHandler.CreateFounder(founder);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{	
			return View(DataHandler.GetClient(id));
		}

		[HttpPost]
		public IActionResult Edit(Client client)
		{
			DataHandler.EditClient(client);
			return RedirectToAction("Index");
		}
	}
}
