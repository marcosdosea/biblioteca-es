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
    public class LivroController : Controller
    {
        GerenciadorLivro gLivro;
        GerenciadorEditora gEditora;
        GerenciadorLivroAutor gLivroAutor;

        public LivroController()
        {
            gLivro = new GerenciadorLivro();
            gEditora = new GerenciadorEditora();
            gLivroAutor = new GerenciadorLivroAutor();
        }
        
        
        //
        // GET: /Livro/
        public ActionResult Index()
        {
            return View(gLivro.ObterTodos());
        }

        //
        // GET: /Livro/
        public ActionResult ListarAutores(string isbn)
        {
            return View(gLivroAutor.ObterAutoresPorLivro(isbn));
        }

        //
        // GET: /Livro/Details/5

        public ActionResult Details(string isbn)
        {
            return View(gLivro.Obter(isbn));
        }

        //
        // GET: /Livro/Create

        public ActionResult Create()
        {
            ViewBag.IdEditora = new SelectList(gEditora.ObterTodos(), "Codigo", "Nome");
            return View();
        } 

        //
        // POST: /Livro/Create

        [HttpPost]
        public ActionResult Create(Livro livroModel)
        {
            if (ModelState.IsValid)
            {
                gLivro.Inserir(livroModel);
                return RedirectToAction("Index");
            }

            return View(livroModel);
        }

        [HttpPost]
        public ActionResult AddAutor(string isbn, int idAutor)
        {
            gLivroAutor.Inserir(isbn, idAutor);
            return RedirectToAction("Edit", new { isbn = isbn });
        }
        
        //
        // GET: /Livro/Edit/5
 
        public ActionResult Edit(string id)
        {
            Livro livroModel = gLivro.Obter(id.ToString());
            ViewBag.IdEditora = new SelectList(gEditora.ObterTodos(), "Codigo", "Nome", livroModel.IdEditora);
            livroModel.ListaAutores = gLivroAutor.ObterAutoresPorLivro(id);
            return View(livroModel);
        }

        //
        // POST: /Livro/Edit/5

        [HttpPost]
        public ActionResult Edit(Livro livroModel)
        {
            if (ModelState.IsValid)
            {
                gLivro.Editar(livroModel);
                return RedirectToAction("Index");
            }
            return View(livroModel);
        }

        //
        // GET: /Livro/Delete/5
 
        public ActionResult Delete(string isbn)
        {
            Livro livroModel = gLivro.Obter(isbn);
            return View(livroModel);
        }

        //
        // POST: /Livro/Delete/5

        [HttpPost]
        public ActionResult Delete(string isbn, Livro livroModel)
        {
            gLivro.Remover(isbn);
            return RedirectToAction("Index");
        }

        public ActionResult RelatorioLivroEditora()
        {
            LocalReport relatorio = new LocalReport();

            //Caminho onde o arquivo do Report Viewer está localizado
            relatorio.ReportPath = Server.MapPath("~/Reports/ReportLivrosPorEditora.rdlc");
            //Define o nome do nosso DataSource e qual rotina irá preenche-lo, no caso, nosso método criado anteriormente
            relatorio.DataSources.Add(new ReportDataSource("DataSetLivro", gLivro.ObterTodos()));

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
