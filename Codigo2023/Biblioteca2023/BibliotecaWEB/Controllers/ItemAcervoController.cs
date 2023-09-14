using AutoMapper;
using BibliotecaWEB.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BibliotecaWEB.Controllers
{
	//[Authorize]
	public class ItemAcervoController : Controller
	{
		private readonly IItemAcervoService _itemAcervoService;
		private readonly IMapper _mapper;

		public ItemAcervoController(IItemAcervoService itemAcervoService, IMapper mapper)
		{
			_itemAcervoService = itemAcervoService;
			_mapper = mapper;
		}


		[AllowAnonymous]
		// GET: ItemAcervoController
		public ActionResult Index()
		{
			var listaItemAcervo = _itemAcervoService.GetAll();
			return View(listaItemAcervo);
		}

		// GET: ItemAcervoController/Details/5
		public ActionResult Details(int id)
		{
			Itemacervo? itemAcervo = _itemAcervoService.Get(id);
			ItemAcervoViewModel itemAcervoModel = _mapper.Map<ItemAcervoViewModel>(itemAcervo);
			return View(itemAcervoModel);
		}

		// GET: ItemAcervoController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ItemAcervoController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ItemAcervoViewModel itemAcervoModel)
		{
			if (ModelState.IsValid)
			{
				var itemAcervo = _mapper.Map<Itemacervo>(itemAcervoModel);
				_itemAcervoService.Create(itemAcervo);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: ItemAcervoController/Edit/5
		public ActionResult Edit(int id)
		{
			Itemacervo itemAcervo = _itemAcervoService.Get(id);
			ItemAcervoViewModel itemAcervoModel = _mapper.Map<ItemAcervoViewModel>(itemAcervo);
			return View(itemAcervoModel);
		}

		// POST: ItemAcervoController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, ItemAcervoViewModel itemAcervoModel)
		{

			if (ModelState.IsValid)
			{
				var itemAcervo = _mapper.Map<Itemacervo>(itemAcervoModel);
				_itemAcervoService.Edit(itemAcervo);
			}
			return RedirectToAction(nameof(Index));
		}

		// GET: ItemAcervoController/Delete/5
		public ActionResult Delete(int id)
		{
			Itemacervo itemAcervo = _itemAcervoService.Get(id);
			ItemAcervoViewModel itemAcervoModel = _mapper.Map<ItemAcervoViewModel>(itemAcervo);
			return View(itemAcervoModel);
		}

		// POST: ItemAcervoController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, ItemAcervoViewModel itemAcervoModel)
		{
			_itemAcervoService.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
