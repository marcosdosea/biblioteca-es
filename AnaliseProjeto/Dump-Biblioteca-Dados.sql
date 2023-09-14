-- MySQL dump 10.13  Distrib 8.0.30, for Win64 (x86_64)
--
-- Host: localhost    Database: biblioteca
-- ------------------------------------------------------
-- Server version	5.7.39-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `autor`
--

DROP TABLE IF EXISTS `autor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autor` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `dataNascimento` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autor`
--

LOCK TABLES `autor` WRITE;
/*!40000 ALTER TABLE `autor` DISABLE KEYS */;
INSERT INTO `autor` VALUES (1,'Machado de Assis','1917-12-31'),(2,'Marcos Barbosa Dósea','1982-01-01'),(3,'Graciliano Ramos','1930-05-13'),(4,'Clarisse Linspector','1927-01-01'),(5,'Lima Barreto','1917-07-13'),(6,'Jorge Amamdo','1920-08-10');
/*!40000 ALTER TABLE `autor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `autorlivro`
--

DROP TABLE IF EXISTS `autorlivro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autorlivro` (
  `idAutor` int(10) unsigned NOT NULL,
  `idLivro` int(10) unsigned NOT NULL,
  PRIMARY KEY (`idAutor`,`idLivro`),
  KEY `fk_AutorLivro_Livro1_idx` (`idLivro`),
  KEY `fk_AutorLivro_Autor1_idx` (`idAutor`),
  CONSTRAINT `fk_AutorLivro_Autor1` FOREIGN KEY (`idAutor`) REFERENCES `autor` (`id`),
  CONSTRAINT `fk_AutorLivro_Livro1` FOREIGN KEY (`idLivro`) REFERENCES `livro` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autorlivro`
--

LOCK TABLES `autorlivro` WRITE;
/*!40000 ALTER TABLE `autorlivro` DISABLE KEYS */;
/*!40000 ALTER TABLE `autorlivro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `biblioteca`
--

DROP TABLE IF EXISTS `biblioteca`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `biblioteca` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `biblioteca`
--

LOCK TABLES `biblioteca` WRITE;
/*!40000 ALTER TABLE `biblioteca` DISABLE KEYS */;
/*!40000 ALTER TABLE `biblioteca` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `devolucao`
--

DROP TABLE IF EXISTS `devolucao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `devolucao` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `idPessoaUsuario` int(10) unsigned NOT NULL,
  `idPessoaBalconista` int(10) unsigned NOT NULL,
  `data` datetime NOT NULL,
  `multa` decimal(10,2) DEFAULT NULL,
  `valorPago` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Devolucao_Pessoa1_idx` (`idPessoaUsuario`),
  KEY `fk_Devolucao_Pessoa2_idx` (`idPessoaBalconista`),
  CONSTRAINT `fk_Devolucao_Pessoa1` FOREIGN KEY (`idPessoaUsuario`) REFERENCES `pessoa` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_Devolucao_Pessoa2` FOREIGN KEY (`idPessoaBalconista`) REFERENCES `pessoa` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devolucao`
--

LOCK TABLES `devolucao` WRITE;
/*!40000 ALTER TABLE `devolucao` DISABLE KEYS */;
/*!40000 ALTER TABLE `devolucao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doacao`
--

DROP TABLE IF EXISTS `doacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doacao` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `data` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doacao`
--

LOCK TABLES `doacao` WRITE;
/*!40000 ALTER TABLE `doacao` DISABLE KEYS */;
/*!40000 ALTER TABLE `doacao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `editora`
--

DROP TABLE IF EXISTS `editora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `editora` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `rua` varchar(30) DEFAULT NULL,
  `bairro` varchar(30) DEFAULT NULL,
  `numero` varchar(10) DEFAULT NULL,
  `cep` varchar(8) DEFAULT NULL,
  `cidade` varchar(30) DEFAULT NULL,
  `estado` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `editora`
--

LOCK TABLES `editora` WRITE;
/*!40000 ALTER TABLE `editora` DISABLE KEYS */;
INSERT INTO `editora` VALUES (1,'Campus','Rua Z','Santo Antônio','s/n','49050445','Aracaju','SE');
/*!40000 ALTER TABLE `editora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emprestimo`
--

DROP TABLE IF EXISTS `emprestimo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `emprestimo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `idPessoaUsuario` int(10) unsigned NOT NULL,
  `idPessoaBalconista` int(10) unsigned NOT NULL,
  `data` datetime NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_Emprestimo_Pessoa1_idx` (`idPessoaUsuario`),
  KEY `fk_Emprestimo_Pessoa2_idx` (`idPessoaBalconista`),
  CONSTRAINT `fk_Emprestimo_Pessoa1` FOREIGN KEY (`idPessoaUsuario`) REFERENCES `pessoa` (`id`) ON UPDATE CASCADE,
  CONSTRAINT `fk_Emprestimo_Pessoa2` FOREIGN KEY (`idPessoaBalconista`) REFERENCES `pessoa` (`id`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emprestimo`
--

LOCK TABLES `emprestimo` WRITE;
/*!40000 ALTER TABLE `emprestimo` DISABLE KEYS */;
/*!40000 ALTER TABLE `emprestimo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemacervo`
--

DROP TABLE IF EXISTS `itemacervo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itemacervo` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `idLivro` int(10) unsigned NOT NULL,
  `idSituacaoItemAcervo` char(1) NOT NULL,
  `idDoacao` int(10) unsigned DEFAULT NULL,
  `dataAquisicao` datetime NOT NULL,
  `idBiblioteca` int(10) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_ItemAcervo_Livro1_idx` (`idLivro`),
  KEY `fk_ItemAcervo_SituacaoItemAcervo1_idx` (`idSituacaoItemAcervo`),
  KEY `fk_ItemAcervo_Doacao1_idx` (`idDoacao`),
  KEY `fk_ItemAcervo_Biblioteca1_idx` (`idBiblioteca`),
  CONSTRAINT `fk_ItemAcervo_Biblioteca1` FOREIGN KEY (`idBiblioteca`) REFERENCES `biblioteca` (`id`),
  CONSTRAINT `fk_ItemAcervo_Doacao1` FOREIGN KEY (`idDoacao`) REFERENCES `doacao` (`id`),
  CONSTRAINT `fk_ItemAcervo_Livro1` FOREIGN KEY (`idLivro`) REFERENCES `livro` (`id`),
  CONSTRAINT `fk_ItemAcervo_SituacaoItemAcervo1` FOREIGN KEY (`idSituacaoItemAcervo`) REFERENCES `situacaoitemacervo` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemacervo`
--

LOCK TABLES `itemacervo` WRITE;
/*!40000 ALTER TABLE `itemacervo` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemacervo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemacervodevolucao`
--

DROP TABLE IF EXISTS `itemacervodevolucao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itemacervodevolucao` (
  `idItemAcervo` int(10) unsigned NOT NULL,
  `idDevolucao` int(10) unsigned NOT NULL,
  PRIMARY KEY (`idItemAcervo`,`idDevolucao`),
  KEY `fk_ItemAcervoDevolucao_Devolucao1_idx` (`idDevolucao`),
  KEY `fk_ItemAcervoDevolucao_ItemAcervo1_idx` (`idItemAcervo`),
  CONSTRAINT `fk_ItemAcervoDevolucao_Devolucao1` FOREIGN KEY (`idDevolucao`) REFERENCES `devolucao` (`id`),
  CONSTRAINT `fk_ItemAcervoDevolucao_ItemAcervo1` FOREIGN KEY (`idItemAcervo`) REFERENCES `itemacervo` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemacervodevolucao`
--

LOCK TABLES `itemacervodevolucao` WRITE;
/*!40000 ALTER TABLE `itemacervodevolucao` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemacervodevolucao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemacervoemprestimo`
--

DROP TABLE IF EXISTS `itemacervoemprestimo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itemacervoemprestimo` (
  `idItemAcervo` int(10) unsigned NOT NULL,
  `idEmprestimo` int(10) unsigned NOT NULL,
  PRIMARY KEY (`idItemAcervo`,`idEmprestimo`),
  KEY `fk_ItemAcervoEmprestimo_Emprestimo1_idx` (`idEmprestimo`),
  KEY `fk_ItemAcervoEmprestimo_ItemAcervo1_idx` (`idItemAcervo`),
  CONSTRAINT `fk_ItemAcervoEmprestimo_Emprestimo1` FOREIGN KEY (`idEmprestimo`) REFERENCES `emprestimo` (`id`),
  CONSTRAINT `fk_ItemAcervoEmprestimo_ItemAcervo1` FOREIGN KEY (`idItemAcervo`) REFERENCES `itemacervo` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `itemacervoemprestimo`
--

LOCK TABLES `itemacervoemprestimo` WRITE;
/*!40000 ALTER TABLE `itemacervoemprestimo` DISABLE KEYS */;
/*!40000 ALTER TABLE `itemacervoemprestimo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `livro`
--

DROP TABLE IF EXISTS `livro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `livro` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `isbn` char(20) NOT NULL,
  `idEditora` int(10) unsigned NOT NULL,
  `nome` varchar(50) NOT NULL,
  `dataPublicacao` date DEFAULT NULL,
  `resumo` varchar(300) DEFAULT NULL,
  `fotoCapa` blob,
  PRIMARY KEY (`id`),
  UNIQUE KEY `isbn_UNIQUE` (`isbn`),
  KEY `fk_Livro_Editora1_idx` (`idEditora`),
  KEY `idx_nome` (`nome`),
  CONSTRAINT `fk_Livro_Editora1` FOREIGN KEY (`idEditora`) REFERENCES `editora` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `livro`
--

LOCK TABLES `livro` WRITE;
/*!40000 ALTER TABLE `livro` DISABLE KEYS */;
/*!40000 ALTER TABLE `livro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `cpf` varchar(11) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `cep` varchar(8) DEFAULT NULL,
  `rua` varchar(45) DEFAULT NULL,
  `numero` varchar(15) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `cidade` varchar(45) DEFAULT NULL,
  `estado` varchar(2) DEFAULT NULL,
  `fone` varchar(12) DEFAULT NULL,
  `fone2` varchar(12) DEFAULT NULL,
  `tipoPessoa` enum('U','B','A') NOT NULL DEFAULT 'U',
  PRIMARY KEY (`id`),
  UNIQUE KEY `cpf_UNIQUE` (`cpf`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pessoa`
--

LOCK TABLES `pessoa` WRITE;
/*!40000 ALTER TABLE `pessoa` DISABLE KEYS */;
/*!40000 ALTER TABLE `pessoa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `situacaoitemacervo`
--

DROP TABLE IF EXISTS `situacaoitemacervo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `situacaoitemacervo` (
  `id` char(1) NOT NULL,
  `situacao` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `situacaoitemacervo`
--

LOCK TABLES `situacaoitemacervo` WRITE;
/*!40000 ALTER TABLE `situacaoitemacervo` DISABLE KEYS */;
INSERT INTO `situacaoitemacervo` VALUES ('D','Disponível'),('E','Emprestado'),('P','Danificado'),('R','Reservado');
/*!40000 ALTER TABLE `situacaoitemacervo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-09-14 12:39:29
