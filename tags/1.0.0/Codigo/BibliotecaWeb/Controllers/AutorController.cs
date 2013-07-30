using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Services;

namespace BibliotecaWeb.Controllers
{ 
    public class AutorController : Controller
    {
        private GerenciadorAutor gAutor;
     
        public AutorController()
        {
            gAutor = new GerenciadorAutor();
        }
        //
        // GET: /Autor/

        public ViewResult Index()
        {
            return View(gAutor.ObterTodos());
        }

        //
        // GET: /Autor/Details/5

        public ViewResult Details(int id)
        {
            Autor autor = gAutor.Obter(id);
            return View(autor);
        }

        //
        // GET: /Autor/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Autor/Create

        [HttpPost]
        public ActionResult Create(Autor autorModel)
        {
            if (ModelState.IsValid)
            {
                gAutor.Inserir(autorModel);
                return RedirectToAction("Index");  
            }

            return View(autorModel);
        }
        
        //
        // GET: /Autor/Edit/5
 
        public ActionResult Edit(int id)
        {

            Autor autor = gAutor.Obter(id);
            return View(autor);
        }

        //
        // POST: /Autor/Edit/5

        [HttpPost]
        public ActionResult Edit(Autor autorModel)
        {
            if (ModelState.IsValid)
            {
                gAutor.Editar(autorModel);
                return RedirectToAction("Index");
            }
            return View(autorModel);
        }

        //
        // GET: /Autor/Delete/5
 
        public ActionResult Delete(int id)
        {
            Autor autoModel = gAutor.Obter(id);
            return View(autoModel);
        }

        //
        // POST: /Autor/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            gAutor.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}