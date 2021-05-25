using AutoMapper;
using Core;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System;
using System.Collections.Generic;

namespace BibliotecaWeb.Controllers.Tests
{
	[TestClass()]
	public class AutorControllerTests
	{
		private static AutorController controller;


		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			// Arrange
			var mockService = new Mock<IAutorService>();
			IMapper mapper = new MapperConfiguration(cfg =>
				cfg.AddProfile(new AutorProfile())).CreateMapper();

			mockService.Setup(service => service.ObterTodos())
				.Returns(GetTestAutores());
			mockService.Setup(service => service.Obter(1))
				.Returns(GetAutor());
			controller = new AutorController(mockService.Object, mapper);
		}

		[TestMethod()]
		[TestCategory("Unit")]
		[Description("Testando o Index")]
		public void IndexTest()
		{
			// Act
			var result = controller.Index();
			
			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AutorModel>));
			List<AutorModel> lista = (List<AutorModel>)viewResult.ViewData.Model;
			Assert.AreEqual(2, lista.Count);
		}

		private static Autor GetAutor()
		{
			return new Autor
			{
				IdAutor = 2,
				Nome = "Machado de Assis",
				AnoNascimento = DateTime.Parse("1935-12-20")
			};
		}

		private static IEnumerable<Autor> GetTestAutores()
		{
			return new List<Autor>
			{
				new Autor
				{
					IdAutor = 1,
					Nome = "Graciliano Ramos",
					AnoNascimento = DateTime.Parse("1920-12-01")
				},
				new Autor
				{
					IdAutor = 2,
					Nome = "Machado de Assis",
					AnoNascimento = DateTime.Parse("1935-12-20")
				},
			};
		}

		[TestMethod()]
		public void DetailsTest()
		{
			// Act
			var result = controller.Details(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AutorModel));
			AutorModel autorModel = (AutorModel) viewResult.ViewData.Model;
			Assert.AreEqual("Machado de Assis", autorModel.Nome);
		}

		[TestMethod()]
		public void CreateTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void CreateTest1()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void EditTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void EditTest1()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteTest()
		{
			Assert.Fail();
		}

		[TestMethod()]
		public void DeleteTest1()
		{
			Assert.Fail();
		}
	}
}