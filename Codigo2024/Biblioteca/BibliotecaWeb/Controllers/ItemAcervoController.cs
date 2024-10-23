using AutoMapper;
using BibliotecaWEB.Models;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace BibliotecaWeb.Controllers
{
    [Authorize]
    public class ItemAcervoController : Controller
    {
        private readonly IItemAcervoService itemAcervoService;
        private readonly IMapper mapper;

        public ItemAcervoController(IItemAcervoService itemAcervoService, IMapper mapper)
        {
            this.itemAcervoService = itemAcervoService;
            this.mapper = mapper;
        }


        // GET: ItemAcervoController
        public ActionResult Index()
        {
            var listaItemAcervo = itemAcervoService.GetAll();
            return View(listaItemAcervo);
        }

        // GET: ItemAcervoController/Details/5
        public ActionResult Details(int id)
        {
            var itemAcervo = itemAcervoService.Get(id);
            ItemAcervoViewModel itemAcervoViewModel = mapper.Map<ItemAcervoViewModel>(itemAcervo);
            return View(itemAcervoViewModel);
        }

        // GET: ItemAcervoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemAcervoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemAcervoViewModel itemAcervoViewModel)
        {
            if (ModelState.IsValid)
            {
                var itemAcervo = mapper.Map<Itemacervo>(itemAcervoViewModel);
                itemAcervoService.Create(itemAcervo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ItemAcervoController/Edit/5
        public ActionResult Edit(int id)
        {
            var itemAcervo = itemAcervoService.Get(id);
            ItemAcervoViewModel itemAcervoViewModel = mapper.Map<ItemAcervoViewModel>(itemAcervo);
            return View(itemAcervoViewModel);
        }

        // POST: ItemAcervoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemAcervoViewModel itemAcervoViewModel)
        {
            if (ModelState.IsValid)
            {
                var itemAcervo = mapper.Map<Itemacervo>(itemAcervoViewModel);
                itemAcervoService.Edit(itemAcervo);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ItemAcervoController/Delete/5
        public ActionResult Delete(int id)
        {
            var itemAcervo = itemAcervoService.Get(id);
            ItemAcervoViewModel itemAcervoViewModel = mapper.Map<ItemAcervoViewModel>(itemAcervo);
            return View(itemAcervoViewModel);
        }

        // POST: ItemAcervoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ItemAcervoViewModel itemAcervoViewModel)
        {
            itemAcervoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
