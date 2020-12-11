using Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Models;
using System.Collections.Generic;

namespace Services.Test
{
    
    
    /// <summary>
    ///This is a test class for GerenciadorAutorTest and is intended
    ///to contain all GerenciadorAutorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GerenciadorAutorTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Um teste de edição com valores válidos
        ///</summary>
        [TestMethod()]
        public void EditarTest()
        {
            // realiza o processo de edição
            GerenciadorAutor gAutor = new GerenciadorAutor(); 
            Autor autorModelExpected = gAutor.Obter(1);
            autorModelExpected.Nome = "Marcos Dósea";
            autorModelExpected.AnoNascimento = new DateTime(1982, 1, 1);
            gAutor.Editar(autorModelExpected);

            // verifica se a edição realizada com sucesso
            Autor autorModelActual = gAutor.Obter(1);
            Assert.AreEqual(autorModelExpected.AnoNascimento, autorModelActual.AnoNascimento);
            Assert.AreEqual(autorModelExpected.Nome, autorModelActual.Nome);
        }


        /// <summary>
        ///Um teste de edição para uma nome muito grande
        ///</summary>
        [TestMethod()]
        public void EditarTest_NomeGrande()
        {
            // realiza o processo de edição
            GerenciadorAutor gAutor = new GerenciadorAutor();
            Autor autorModelExpected = gAutor.Obter(1);
            autorModelExpected.Nome = "José dos Santos Barbosa Arimateia Vergueiro de Oliveira Dósea";
            autorModelExpected.AnoNascimento = new DateTime(1982, 1, 1);
            gAutor.Editar(autorModelExpected);

            // verifica se a edição realizada com sucesso
            Autor autorModelActual = gAutor.Obter(1);
            Assert.AreEqual(autorModelExpected.AnoNascimento, autorModelActual.AnoNascimento);
            Assert.AreEqual(autorModelExpected.Nome, autorModelActual.Nome);
        }


        /// <summary>
        ///Um teste de edição para uma data muito antiga
        ///</summary>
        [TestMethod()]
        public void EditarTest_DataMenorDoQueMil()
        {
            // realiza o processo de edição
            GerenciadorAutor gAutor = new GerenciadorAutor();
            Autor autorModelExpected = gAutor.Obter(1);
            autorModelExpected.Nome = "Marcos Dósea";
            autorModelExpected.AnoNascimento = new DateTime(100, 1, 1);
            
            // verifica se exceção de serviço foi lançada
            try
            {
                gAutor.Editar(autorModelExpected);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ServiceException));
            }
        }

        /// <summary>
        ///A test for Inserir
        ///</summary>
        [TestMethod()]
        public void InserirTest()
        {
            GerenciadorAutor target = new GerenciadorAutor(); // TODO: Initialize to an appropriate value
            Autor autorModel = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Inserir(autorModel);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Obter
        ///</summary>
        [TestMethod()]
        public void ObterTest()
        {
            GerenciadorAutor target = new GerenciadorAutor(); // TODO: Initialize to an appropriate value
            int idAutor = 0; // TODO: Initialize to an appropriate value
            Autor expected = null; // TODO: Initialize to an appropriate value
            Autor actual;
            actual = target.Obter(idAutor);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ObterTodos
        ///</summary>
        [TestMethod()]
        public void ObterTodosTest()
        {
            GerenciadorAutor target = new GerenciadorAutor(); // TODO: Initialize to an appropriate value
            IEnumerable<Autor> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Autor> actual;
            actual = target.ObterTodos();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Remover
        ///</summary>
        [TestMethod()]
        public void RemoverTest()
        {
            GerenciadorAutor target = new GerenciadorAutor(); // TODO: Initialize to an appropriate value
            int idAutor = 0; // TODO: Initialize to an appropriate value
            target.Remover(idAutor);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
