using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Tests
{
	[TestClass()]
	public class AutorServiceTests
	{
		private BibliotecaContext _context;
		private IAutorService _autorService;

		[TestInitialize]
		public void Initialize()
		{
			//Arrange
			var builder = new DbContextOptionsBuilder<BibliotecaContext>();
			builder.UseInMemoryDatabase("Biblioteca");
			var options = builder.Options;

			_context = new BibliotecaContext(options);
			_context.Database.EnsureDeleted();
			_context.Database.EnsureCreated();
			var autores = new List<Autor>
				{
					new Autor { IdAutor = 1, Nome = "Machado de Assis", AnoNascimento = DateTime.Parse("1917-12-31")},
					new Autor { IdAutor = 2, Nome = "Ian S. Sommervile", AnoNascimento = DateTime.Parse("1935-12-31")},
					new Autor { IdAutor = 3, Nome = "Gleford Myers", AnoNascimento = DateTime.Parse("1900-11-20")},
				};

			_context.AddRange(autores);
			_context.SaveChanges();

			_autorService = new AutorService(_context);
		}


		[TestMethod()]
		public void InserirTest()
		{
			// Act
			_autorService.Inserir(new Autor() { IdAutor = 4, Nome = "Graciliano Ramos", AnoNascimento = DateTime.Parse("1900-12-25") });
			// Assert
			Assert.AreEqual(4, _autorService.ObterTodos().Count());
			var autor = _autorService.Obter(4);
			Assert.AreEqual("Graciliano Ramos", autor.Nome);
			Assert.AreEqual(DateTime.Parse("1900-12-25"), autor.AnoNascimento);
		}

		[TestMethod()]
		public void EditarTest()
		{
			//Act 
			var autor = _autorService.Obter(3);
			autor.Nome = "Paulo Coelho";
			autor.AnoNascimento = DateTime.Parse("1950-11-21");
			_autorService.Editar(autor);
			//Assert
			autor = _autorService.Obter(3);
			Assert.AreEqual("Paulo Coelho", autor.Nome);
			Assert.AreEqual(DateTime.Parse("1950-11-21"), autor.AnoNascimento);
		}

		[TestMethod()]
		public void RemoverTest()
		{
			// Act
			_autorService.Remover(2);
			// Assert
			Assert.AreEqual(2, _autorService.ObterTodos().Count());
			var autor = _autorService.Obter(2);
			Assert.AreEqual(null, autor);
		}

		[TestMethod()]
		public void ObterTodosTest()
		{
			// Act
			var listaAutor = _autorService.ObterTodos();
			// Assert
			Assert.IsInstanceOfType(listaAutor, typeof(IEnumerable<Autor>));
			Assert.IsNotNull(listaAutor);
			Assert.AreEqual(3, listaAutor.Count());
			Assert.AreEqual(1, listaAutor.First().IdAutor);
			Assert.AreEqual("Machado de Assis", listaAutor.First().Nome);
		}

		[TestMethod()]
		public void ObterTodosOrdenadoPorNomeTest()
		{
			var listaAutor = _autorService.ObterTodosOrdenadoPorNome();
			Assert.IsInstanceOfType(listaAutor, typeof(IEnumerable<Autor>));
			Assert.IsNotNull(listaAutor);
			Assert.AreNotEqual(0, listaAutor.Count());
			Assert.AreEqual(3, listaAutor.First().IdAutor);
			Assert.AreEqual("Gleford Myers", listaAutor.First().Nome);
		}

		[TestMethod()]
		public void ObterTest()
		{
			var autor = _autorService.Obter(1);
			Assert.IsNotNull(autor);
			Assert.AreEqual("Machado de Assis", autor.Nome);
		}

		[TestMethod()]
		public void ObterPorNomeTest()
		{
			var autores = _autorService.ObterPorNome("Machado");
			Assert.IsNotNull(autores);
			Assert.AreEqual(1, autores.Count());
			Assert.AreEqual("Machado de Assis", autores.First().Nome);
		}

		[TestMethod()]
		public void ObterPorNomeContendoTest()
		{
			var autores = _autorService.ObterPorNomeContendo("Sommervile");
			Assert.IsNotNull(autores);
			Assert.AreEqual(1, autores.Count());
			Assert.AreEqual("Ian S. Sommervile", autores.First().Nome);
		}

		[TestMethod()]
		public void ObterPorNomeOrdenadoDescendingTest()
		{
			var autores = _autorService.ObterPorNomeOrdenadoDescending("Ia");
			Assert.IsNotNull(autores);
			Assert.AreEqual(1, autores.Count());
			Assert.AreEqual("Ian S. Sommervile", autores.First().Nome);
		}
	}
}