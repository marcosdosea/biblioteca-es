using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Models;

namespace BibliotecaWeb.Controllers
{
    public class EditoraController : Controller
    {
        //
        // GET: /Editora/

        GerenciadorEditora gEditora;

        public EditoraController()
        {
            gEditora = new GerenciadorEditora();
        }

        public ActionResult Index()
        {
            return View(gEditora.ObterTodos());
        }

        //
        // GET: /Editora/Details/5

        public ActionResult Details(int id)
        {
            return View(gEditora.Obter(id));
        }

        //
        // GET: /Editora/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Editora/Create

        [HttpPost]
        public ActionResult Create(Editora editoraModel)
        {
            if (ModelState.IsValid)
            {
                gEditora.Inserir(editoraModel);
                return RedirectToAction("Index");
            }

            return View(editoraModel);
        }
        
        //
        // GET: /Editora/Edit/5
 
        public ActionResult Edit(int id)
        {
            Editora editoraModel = gEditora.Obter(id);
            return View(editoraModel);
        }

        //
        // POST: /Editora/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Editora editoraModel)
        {
            if (ModelState.IsValid)
            {
                gEditora.Editar(editoraModel);
                return RedirectToAction("Index");
            }
            return View(editoraModel);
        }

        //
        // GET: /Editora/Delete/5
 
        public ActionResult Delete(int id)
        {
            Editora editoraModel = gEditora.Obter(id);
            return View(editoraModel);
        }

        //
        // POST: /Editora/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, Editora editoraModel)
        {
            gEditora.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
