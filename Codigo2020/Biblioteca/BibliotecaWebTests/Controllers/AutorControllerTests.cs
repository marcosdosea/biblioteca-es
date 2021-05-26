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
				.Returns(GetTargetAutor());
			mockService.Setup(service => service.Editar(It.IsAny<Autor>()))
				.Verifiable(); 
			mockService.Setup(service => service.Inserir(It.IsAny<Autor>()))
				.Verifiable();
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
			// Act
			var result = controller.Create();
			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
		}

		[TestMethod()]
		public void CreateTest_Valid()
		{
			// Act
			var result = controller.Create(GetNewAutor());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void CreateTest_InValid()
		{
			// Arrange
			controller.ModelState.AddModelError("Nome", "Campo requerido");

			// Act
			var result = controller.Create(GetNewAutor());

			// Assert
			Assert.AreEqual(1, controller.ModelState.ErrorCount); 
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void EditTest()
		{
			// Act
			var result = controller.Edit(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AutorModel));
			AutorModel autorModel = (AutorModel)viewResult.ViewData.Model;
			Assert.AreEqual("Machado de Assis", autorModel.Nome);
		}

		[TestMethod()]
		public void EditTest1()
		{
			// Act
			var result = controller.Edit(GetTargetAutorModel().IdAutor, GetTargetAutorModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		[TestMethod()]
		public void DeleteTest()
		{
			// Act
			var result = controller.Delete(1);

			// Assert
			Assert.IsInstanceOfType(result, typeof(ViewResult));
			ViewResult viewResult = (ViewResult)result;
			Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AutorModel));
			AutorModel autorModel = (AutorModel)viewResult.ViewData.Model;
			Assert.AreEqual("Machado de Assis", autorModel.Nome);
		}

		[TestMethod()]
		public void DeleteTest_Valid()
		{
			// Act
			var result = controller.Delete(GetTargetAutorModel().IdAutor, GetTargetAutorModel());

			// Assert
			Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
			RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
			Assert.IsNull(redirectToActionResult.ControllerName);
			Assert.AreEqual("Index", redirectToActionResult.ActionName);
		}

		private static AutorModel GetNewAutor()
		{
			return new AutorModel 
			{ 
				IdAutor = 3, 
				Nome = "Ian Sommerville", 
				AnoNascimento = DateTime.Parse("1951-02-23") 
			};

		}
		private static Autor GetTargetAutor()
		{
			return new Autor
			{
				IdAutor = 2,
				Nome = "Machado de Assis",
				AnoNascimento = DateTime.Parse("1935-12-20")
			};
		}

		private static AutorModel GetTargetAutorModel()
		{
			return new AutorModel
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
	}
}