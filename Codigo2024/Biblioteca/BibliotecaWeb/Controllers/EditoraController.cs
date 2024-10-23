using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace BibliotecaWeb.Controllers
{
    [Authorize]
    public class EditoraController : Controller
    {
        private readonly IEditoraService editoraService;
        private readonly IMapper mapper;

        public EditoraController(IEditoraService editoraService, IMapper mapper)
        {
            this.editoraService = editoraService;
            this.mapper = mapper;
        }


        // GET: EditoraController
        public ActionResult Index()
        {
            var listaEditoras = editoraService.GetAll();
            var listaEditorasModel = mapper.Map<List<EditoraViewModel>>(listaEditoras);
            return View(listaEditorasModel);
        }

        // GET: EditoraController/Details/5
        public ActionResult Details(int id)
        {
            var editora = editoraService.Get(id);
            EditoraViewModel editoraViewModel = mapper.Map<EditoraViewModel>(editora);
            return View(editoraViewModel);
        }

        // GET: EditoraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EditoraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EditoraViewModel editoraViewModel)
        {
            if (ModelState.IsValid)
            {
                var editora = mapper.Map<Editora>(editoraViewModel);
                editoraService.Create(editora);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EditoraController/Edit/5
        public ActionResult Edit(int id)
        {
            var editora = editoraService.Get(id);
            EditoraViewModel editoraViewModel = mapper.Map<EditoraViewModel>(editora);
            return View(editoraViewModel);
        }

        // POST: EditoraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditoraViewModel editoraModel)
        {
            if (ModelState.IsValid)
            {
                var editora = mapper.Map<Editora>(editoraModel);
                editoraService.Edit(editora);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EditoraController/Delete/5
        public ActionResult Delete(int id)
        {
            var editora = editoraService.Get(id);
            EditoraViewModel editoraViewModel = mapper.Map<EditoraViewModel>(editora);
            return View(editoraViewModel);
        }

        // POST: EditoraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, EditoraViewModel editoraModel)
        {
            editoraService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
