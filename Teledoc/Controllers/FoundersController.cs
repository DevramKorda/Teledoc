using Microsoft.AspNetCore.Mvc;
using Teledoc.Models;
using Teledoc.Services;

namespace Teledoc.Controllers
{
	public class FoundersController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View(DataHandler.GetFounders());
		}

		[HttpGet]
		public IActionResult Details(int id)
		{
			return View(DataHandler.GetFounderDetails(id));
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			return View(DataHandler.GetFounder(id));
		}

		[HttpPost]
		public IActionResult Edit(Founder founder)
		{
			DataHandler.EditFounder(founder);
			return RedirectToAction("Index");
		}
	}
}
