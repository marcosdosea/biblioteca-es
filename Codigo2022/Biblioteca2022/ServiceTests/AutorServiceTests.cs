using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
		public void CreateTest()
		{
			// Act
			_autorService.Create(new Autor() { IdAutor = 4, Nome = "Graciliano Ramos", AnoNascimento = DateTime.Parse("1900-12-25") });
			// Assert
			Assert.AreEqual(4, _autorService.GetAll().Count());
			var autor = _autorService.Get(4);
			Assert.AreEqual("Graciliano Ramos", autor.Nome);
			Assert.AreEqual(DateTime.Parse("1900-12-25"), autor.AnoNascimento);
		}

		[TestMethod()]
		public void DeleteTest()
		{
			// Act
			_autorService.Delete(2);
			// Assert
			Assert.AreEqual(2, _autorService.GetAll().Count());
			var autor = _autorService.Get(2);
			Assert.AreEqual(null, autor);
		}

		[TestMethod()]
		public void EditTest()
		{
			//Act 
			var autor = _autorService.Get(3);
			autor.Nome = "Paulo Coelho";
			autor.AnoNascimento = DateTime.Parse("1950-11-21");
			_autorService.Edit(autor);
			//Assert
			autor = _autorService.Get(3);
			Assert.IsNotNull(autor);
			Assert.AreEqual("Paulo Coelho", autor.Nome);
			Assert.AreEqual(DateTime.Parse("1950-11-21"), autor.AnoNascimento);
		}

		[TestMethod()]
		public void GetTest()
		{
			var autor = _autorService.Get(1);
			Assert.IsNotNull(autor);
			Assert.AreEqual("Machado de Assis", autor.Nome);
			Assert.AreEqual(DateTime.Parse("1917-12-31"), autor.AnoNascimento);
		}

		[TestMethod()]
		public void GetAllTest()
		{
			// Act
			var listaAutor = _autorService.GetAll();
			// Assert
			Assert.IsInstanceOfType(listaAutor, typeof(IEnumerable<Autor>));
			Assert.IsNotNull(listaAutor);
			Assert.AreEqual(3, listaAutor.Count());
			Assert.AreEqual(1, listaAutor.First().IdAutor);
			Assert.AreEqual("Machado de Assis", listaAutor.First().Nome);
		}

		[TestMethod()]
		public void GetByNomeTest()
		{
			//Act
			var autores = _autorService.GetByNome("Machado");
			//Assert
			Assert.IsNotNull(autores);
			Assert.AreEqual(1, autores.Count());
			Assert.AreEqual("Machado de Assis", autores.First().Nome);
		}
	}
}