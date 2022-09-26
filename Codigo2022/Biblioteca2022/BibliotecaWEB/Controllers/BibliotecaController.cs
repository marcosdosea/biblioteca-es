using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWEB.Controllers
{
	public class BibliotecaController : Controller
	{
		// GET: BibliotecaController
		public ActionResult Index()
		{
			return View();
		}

		// GET: BibliotecaController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: BibliotecaController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BibliotecaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: BibliotecaController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: BibliotecaController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: BibliotecaController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: BibliotecaController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
