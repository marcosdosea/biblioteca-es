using AutoMapper;
using BibliotecaWEB.Models;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BibliotecaWEB.Controllers
{
	public class ItemAcervoController : Controller
	{
		private readonly IItemAcervoService _itemAcervoService;
		private readonly IMapper _mapper;

		public ItemAcervoController(IItemAcervoService itemAcervoService, IMapper mapper)
		{
			_itemAcervoService = itemAcervoService;
			_mapper = mapper;
		}

	
		// GET: ItemAcervoController
		public ActionResult Index()
		{
			var listaItemAcervo = _itemAcervoService.GetAll();
			var listaItemAcervoModel = _mapper.Map<List<ItemAcervoModel>>(listaItemAcervo);
			return View(listaItemAcervoModel);
		}

		// GET: ItemAcervoController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ItemAcervoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ItemAcervoController/Create
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

		// GET: ItemAcervoController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ItemAcervoController/Edit/5
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

		// GET: ItemAcervoController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ItemAcervoController/Delete/5
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
