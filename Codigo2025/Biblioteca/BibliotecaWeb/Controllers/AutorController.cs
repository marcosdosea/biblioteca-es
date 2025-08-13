using AutoMapper;
using Core;
using Core.Datatables;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace BibliotecaWeb.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorService autorService;
        private readonly IMapper mapper;

        public AutorController(IAutorService autorService, IMapper mapper)
        {
            this.autorService = autorService;
            this.mapper = mapper;
        }

        // GET: AutorController
        public ActionResult Index()
        {
            var listaAutores = autorService.GetAll();
            var listaAutorViewModel = mapper.Map<List<AutorViewModel>>(listaAutores);
            return View(listaAutorViewModel);
        }

        // GET: AutorController/Details/5
        public ActionResult Details(uint id)
        {
            var autor = autorService.Get(id);
            var autorViewModel = mapper.Map<AutorViewModel>(autor);
            return View(autorViewModel);
        }

        [HttpPost]
        public IActionResult GetDataPage(DatatableRequest request)
        {
            var response = autorService.GetDataPage(request);
            return Json(response);
        }

        // GET: AutorController/Create
        public ActionResult Create()
        {
            var autorViewModel = new AutorViewModel();
            autorViewModel.DataNascimento = DateTime.Now;
            return View(autorViewModel);
        }

        // POST: AutorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutorViewModel autorViewModel)
        {
            if (ModelState.IsValid)
            {
                var autor = mapper.Map<Autor>(autorViewModel);
                autorService.Create(autor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AutorController/Edit/5
        public ActionResult Edit(uint id)
        {
            var autor = autorService.Get(id);
            var autorViewModel = mapper.Map<AutorViewModel>(autor);
            return View(autorViewModel);
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(uint id, AutorViewModel autorViewModel)
        {
            if (ModelState.IsValid)
            {
                var autor = mapper.Map<Autor>(autorViewModel);
                autorService.Edit(autor);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: AutorController/Delete/5
        public ActionResult Delete(uint id)
        {
            var autor = autorService.Get(id);
            var autorViewModel = mapper.Map<AutorViewModel>(autor);
            return View(autorViewModel);
        }

        // POST: AutorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AutorViewModel autorViewModel)
        {
            autorService.Delete(autorViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
