using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using Services;
using Microsoft.Reporting.WebForms;

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

        public ActionResult RelatorioAutor()
        {
            LocalReport relatorio = new LocalReport();

            //Caminho onde o arquivo do Report Viewer está localizado
            relatorio.ReportPath = Server.MapPath("~/Reports/ReportListaAutor.rdlc");
            //Define o nome do nosso DataSource e qual rotina irá preenche-lo, no caso, nosso método criado anteriormente
            relatorio.DataSources.Add(new ReportDataSource("DataSetAutor", gAutor.ObterTodos()));

            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =
             "<DeviceInfo>" +
             " <OutputFormat>PDF</OutputFormat>" +
             " <PageWidth>9in</PageWidth>" +
             " <PageHeight>11in</PageHeight>" +
             " <MarginTop>0.7in</MarginTop>" +
             " <MarginLeft>2in</MarginLeft>" +
             " <MarginRight>2in</MarginRight>" +
             " <MarginBottom>0.7in</MarginBottom>" +
             "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] bytes;

            //Renderiza o relatório em bytes
            bytes = relatorio.Render(
            reportType,
            deviceInfo,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings);

            return File(bytes, mimeType);

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}