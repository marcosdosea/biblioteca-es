using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using Models;
using Microsoft.Reporting.WebForms;

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

        public ActionResult RelatorioEditoras()
        {
            LocalReport relatorio = new LocalReport();

            //Caminho onde o arquivo do Report Viewer está localizado
            relatorio.ReportPath = Server.MapPath("~/Reports/ReportListEditora.rdlc");
            //Define o nome do nosso DataSource e qual rotina irá preenche-lo, no caso, nosso método criado anteriormente
            relatorio.DataSources.Add(new ReportDataSource("DataSetEditora", gEditora.ObterTodos()));

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
    }
}
