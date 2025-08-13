using AutoMapper;
using Core;
using Core.Service;
using Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;

namespace BibliotecaWeb.Controllers.Tests
{
    [TestClass()]
    public class AutorControllerTests
    {
        private static AutorController controller;

        [TestInitialize]
        public void Initialize()
        {
            // Arrange
            var mockService = new Mock<IAutorService>();

            IMapper mapper = new MapperConfiguration(cfg =>
                cfg.AddProfile(new AutorProfile())).CreateMapper();

            mockService.Setup(service => service.GetAll())
                .Returns(GetTestAutores());
            mockService.Setup(service => service.Get(1))
                .Returns(GetTargetAutor());
            mockService.Setup(service => service.Edit(It.IsAny<Autor>()))
                .Verifiable();
            mockService.Setup(service => service.Create(It.IsAny<Autor>()))
                .Verifiable();
            controller = new AutorController(mockService.Object, mapper);
        }

        [TestMethod()]
        public void IndexTest_Valido()
        {
            // Act
            var result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(List<AutorViewModel>));

            List<AutorViewModel>? lista = (List<AutorViewModel>)viewResult.ViewData.Model;
            Assert.AreEqual(3, lista.Count);
        }

        [TestMethod()]
        public void DetailsTest_Valido()
        {
            // Act
            var result = controller.Details(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AutorViewModel));
            AutorViewModel autorModel = (AutorViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", autorModel.Nome);
            Assert.AreEqual(DateTime.Parse("1839-06-21"), autorModel.DataNascimento);
        }

        [TestMethod()]
        public void CreateTest_Get_Valido()
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
        public void CreateTest_Post_Invalid()
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
        public void EditTest_Get_Valid()
        {
            // Act
            var result = controller.Edit(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AutorViewModel));
            AutorViewModel autorModel = (AutorViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", autorModel.Nome);
            Assert.AreEqual(DateTime.Parse("1839-06-21"), autorModel.DataNascimento);
        }

        [TestMethod()]
        public void EditTest_Post_Valid()
        {
            // Act
            var result = controller.Edit(GetTargetAutorModel().Id, GetTargetAutorModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        [TestMethod()]
        public void DeleteTest_Post_Valid()
        {
            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
            ViewResult viewResult = (ViewResult)result;
            Assert.IsInstanceOfType(viewResult.ViewData.Model, typeof(AutorViewModel));
            AutorViewModel autorModel = (AutorViewModel)viewResult.ViewData.Model;
            Assert.AreEqual("Machado de Assis", autorModel.Nome);
            Assert.AreEqual(DateTime.Parse("1839-06-21"), autorModel.DataNascimento);
        }

        [TestMethod()]
        public void DeleteTest_Get_Valid()
        {
            // Act
            var result = controller.Delete(GetTargetAutorModel());

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
            RedirectToActionResult redirectToActionResult = (RedirectToActionResult)result;
            Assert.IsNull(redirectToActionResult.ControllerName);
            Assert.AreEqual("Index", redirectToActionResult.ActionName);
        }

        private AutorViewModel GetNewAutor()
        {
            return new AutorViewModel
            {
                Id = 4,
                Nome = "Ian Sommerville",
                DataNascimento = DateTime.Parse("1951-02-23")
            };

        }
        private static Autor GetTargetAutor()
        {
            return new Autor
            {
                Id = 1,
                Nome = "Machado de Assis",
                DataNascimento = DateTime.Parse("1839-06-21")
            };
        }

        private AutorViewModel GetTargetAutorModel()
        {
            return new AutorViewModel
            {
                Id = 2,
                Nome = "Machado de Assis",
                DataNascimento = DateTime.Parse("1839-06-21")
            };
        }

        private IEnumerable<Autor> GetTestAutores()
        {
            return new List<Autor>
            {
                new Autor
                {
                    Id = 1,
                    Nome = "Graciliano Ramos",
                    DataNascimento = DateTime.Parse("1892-10-27")
                },
                new Autor
                {
                    Id = 2,
                    Nome = "Machado de Assis",
                    DataNascimento = DateTime.Parse("1839-06-21")
                },
                new Autor
                {
                    Id = 3,
                    Nome = "Marcos Dósea",
                    DataNascimento = DateTime.Parse("1982-01-01")
                },
            };
        }
    }
}