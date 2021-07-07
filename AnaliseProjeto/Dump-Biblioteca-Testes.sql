CREATE DATABASE  IF NOT EXISTS `biblioteca` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `biblioteca`;
-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: biblioteca
-- ------------------------------------------------------
-- Server version	5.5.8

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
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20210208035653_CreateIdentitySchema','3.1.10');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('1','USUARIO','USUARIO',NULL),('2','BALCONISTA','BALCONISTA',NULL),('3','BIBLIOTECARIO','BIBLIOTECARIO',NULL);
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(767) NOT NULL,
  `ClaimType` text,
  `ClaimValue` text,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(128) NOT NULL,
  `ProviderKey` varchar(128) NOT NULL,
  `ProviderDisplayName` text,
  `UserId` varchar(767) NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(767) NOT NULL,
  `RoleId` varchar(767) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('7ba31306-9a4b-4df2-bcc0-07f27d0f665a','2');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('7ba31306-9a4b-4df2-bcc0-07f27d0f665a','dosea@ufs.br','DOSEA@UFS.BR','dosea@ufs.br','DOSEA@UFS.BR',_binary '','AQAAAAEAACcQAAAAEIb4XmKz3tS6ixGL/AdkI98h8av640K4yNgr2e9nL8PCyol/7Z0Y4NVIVtLiHh+4Gw==','NXGHQPYDFZHHPLNXVNHFR4F3L2F6VO6E','254fa4a0-68de-47a2-8b6c-d418b19a9989',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(767) NOT NULL,
  `LoginProvider` varchar(128) NOT NULL,
  `Name` varchar(128) NOT NULL,
  `Value` text,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `autor`
--

DROP TABLE IF EXISTS `autor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autor` (
  `idAutor` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `anoNascimento` date NOT NULL,
  PRIMARY KEY (`idAutor`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `autor`
--

LOCK TABLES `autor` WRITE;
/*!40000 ALTER TABLE `autor` DISABLE KEYS */;
INSERT INTO `autor` VALUES (1,'marcos dosea','1990-01-01');
/*!40000 ALTER TABLE `autor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `autorlivro`
--

DROP TABLE IF EXISTS `autorlivro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `autorlivro` (
  `idAutor` int(11) NOT NULL,
  `idLivro` int(10) unsigned NOT NULL,
  PRIMARY KEY (`idAutor`,`idLivro`),
  KEY `fk_AutorLivro_Livro1_idx` (`idLivro`),
  KEY `fk_AutorLivro_Autor1_idx` (`idAutor`),
  CONSTRAINT `fk_AutorLivro_Autor1` FOREIGN KEY (`idAutor`) REFERENCES `autor` (`idAutor`) ON UPDATE CASCADE,
  CONSTRAINT `fk_AutorLivro_Livro1` FOREIGN KEY (`idLivro`) REFERENCES `livro` (`idLivro`) ON UPDATE CASCADE
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
  `idBiblioteca` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idBiblioteca`)
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
  `idDevolucao` int(11) NOT NULL AUTO_INCREMENT,
  `idPessoaUsuario` int(11) NOT NULL,
  `idPessoaBalconista` int(11) NOT NULL,
  `data` datetime DEFAULT NULL,
  `multa` decimal(10,2) DEFAULT NULL,
  `valorPago` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idDevolucao`),
  KEY `fk_Devolucao_Pessoa1_idx` (`idPessoaUsuario`),
  KEY `fk_Devolucao_Pessoa2_idx` (`idPessoaBalconista`),
  CONSTRAINT `fk_Devolucao_Pessoa1` FOREIGN KEY (`idPessoaUsuario`) REFERENCES `pessoa` (`idPessoa`) ON UPDATE CASCADE,
  CONSTRAINT `fk_Devolucao_Pessoa2` FOREIGN KEY (`idPessoaBalconista`) REFERENCES `pessoa` (`idPessoa`) ON UPDATE CASCADE
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
-- Table structure for table `devolucaoitemacervo`
--

DROP TABLE IF EXISTS `devolucaoitemacervo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `devolucaoitemacervo` (
  `idDevolucao` int(11) NOT NULL,
  `idItemAcervo` int(11) NOT NULL,
  PRIMARY KEY (`idDevolucao`,`idItemAcervo`),
  KEY `fk_Devolucao_has_ItemAcervo_ItemAcervo1_idx` (`idItemAcervo`),
  KEY `fk_Devolucao_has_ItemAcervo_Devolucao1_idx` (`idDevolucao`),
  CONSTRAINT `fk_Devolucao_has_ItemAcervo_Devolucao1` FOREIGN KEY (`idDevolucao`) REFERENCES `devolucao` (`idDevolucao`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Devolucao_has_ItemAcervo_ItemAcervo1` FOREIGN KEY (`idItemAcervo`) REFERENCES `itemacervo` (`idItemAcervo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `devolucaoitemacervo`
--

LOCK TABLES `devolucaoitemacervo` WRITE;
/*!40000 ALTER TABLE `devolucaoitemacervo` DISABLE KEYS */;
/*!40000 ALTER TABLE `devolucaoitemacervo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doacao`
--

DROP TABLE IF EXISTS `doacao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `doacao` (
  `idDoacao` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime DEFAULT NULL,
  PRIMARY KEY (`idDoacao`)
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
  `idEditora` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(45) NOT NULL,
  `rua` varchar(30) DEFAULT NULL,
  `bairro` varchar(30) DEFAULT NULL,
  `numero` varchar(10) DEFAULT NULL,
  `cep` varchar(8) DEFAULT NULL,
  `cidade` varchar(30) DEFAULT NULL,
  `estado` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`idEditora`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `editora`
--

LOCK TABLES `editora` WRITE;
/*!40000 ALTER TABLE `editora` DISABLE KEYS */;
INSERT INTO `editora` VALUES (1,'Etica',NULL,NULL,NULL,NULL,NULL,NULL),(2,'Atlas',NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `editora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emprestimo`
--

DROP TABLE IF EXISTS `emprestimo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `emprestimo` (
  `idEmprestimo` int(11) NOT NULL AUTO_INCREMENT,
  `idPessoaUsuario` int(11) NOT NULL,
  `idPessoaBalconista` int(11) NOT NULL,
  `data` datetime NOT NULL,
  PRIMARY KEY (`idEmprestimo`),
  KEY `fk_Emprestimo_Pessoa1_idx` (`idPessoaUsuario`),
  KEY `fk_Emprestimo_Pessoa2_idx` (`idPessoaBalconista`),
  CONSTRAINT `fk_Emprestimo_Pessoa1` FOREIGN KEY (`idPessoaUsuario`) REFERENCES `pessoa` (`idPessoa`) ON UPDATE CASCADE,
  CONSTRAINT `fk_Emprestimo_Pessoa2` FOREIGN KEY (`idPessoaBalconista`) REFERENCES `pessoa` (`idPessoa`) ON UPDATE CASCADE
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
-- Table structure for table `emprestimoitemacervo`
--

DROP TABLE IF EXISTS `emprestimoitemacervo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `emprestimoitemacervo` (
  `idItemAcervo` int(11) NOT NULL,
  `idEmprestimo` int(11) NOT NULL,
  PRIMARY KEY (`idItemAcervo`,`idEmprestimo`),
  KEY `fk_ItemAcervo_has_Emprestimo_Emprestimo1_idx` (`idEmprestimo`),
  KEY `fk_ItemAcervo_has_Emprestimo_ItemAcervo1_idx` (`idItemAcervo`),
  CONSTRAINT `fk_ItemAcervo_has_Emprestimo_Emprestimo1` FOREIGN KEY (`idEmprestimo`) REFERENCES `emprestimo` (`idEmprestimo`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ItemAcervo_has_Emprestimo_ItemAcervo1` FOREIGN KEY (`idItemAcervo`) REFERENCES `itemacervo` (`idItemAcervo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emprestimoitemacervo`
--

LOCK TABLES `emprestimoitemacervo` WRITE;
/*!40000 ALTER TABLE `emprestimoitemacervo` DISABLE KEYS */;
/*!40000 ALTER TABLE `emprestimoitemacervo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `itemacervo`
--

DROP TABLE IF EXISTS `itemacervo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `itemacervo` (
  `idItemAcervo` int(11) NOT NULL,
  `idLivro` int(10) unsigned NOT NULL,
  `idBiblioteca` int(11) NOT NULL,
  `idSituacaoLivro` char(1) NOT NULL,
  `idDoacao` int(11) DEFAULT NULL,
  PRIMARY KEY (`idItemAcervo`),
  KEY `fk_ItemAcervo_Biblioteca1_idx` (`idBiblioteca`),
  KEY `fk_ItemAcervo_SituacaoLivro1_idx` (`idSituacaoLivro`),
  KEY `fk_ItemAcervo_Doacao1_idx` (`idDoacao`),
  KEY `fk_ItemAcervo_Livro1_idx` (`idLivro`),
  CONSTRAINT `fk_ItemAcervo_Biblioteca1` FOREIGN KEY (`idBiblioteca`) REFERENCES `biblioteca` (`idBiblioteca`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ItemAcervo_Doacao1` FOREIGN KEY (`idDoacao`) REFERENCES `doacao` (`idDoacao`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ItemAcervo_Livro1` FOREIGN KEY (`idLivro`) REFERENCES `livro` (`idLivro`) ON UPDATE CASCADE,
  CONSTRAINT `fk_ItemAcervo_SituacaoLivro1` FOREIGN KEY (`idSituacaoLivro`) REFERENCES `situacaolivro` (`idSituacaoLivro`) ON DELETE NO ACTION ON UPDATE NO ACTION
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
-- Table structure for table `livro`
--

DROP TABLE IF EXISTS `livro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `livro` (
  `idLivro` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `isbn` char(20) NOT NULL,
  `idEditora` int(11) NOT NULL,
  `nome` varchar(50) DEFAULT NULL,
  `dataPublicacao` date DEFAULT NULL,
  `resumo` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`idLivro`),
  UNIQUE KEY `isbn_UNIQUE` (`isbn`),
  KEY `fk_Livro_Editora1_idx` (`idEditora`),
  KEY `idx_nome` (`nome`),
  CONSTRAINT `fk_Livro_Editora1` FOREIGN KEY (`idEditora`) REFERENCES `editora` (`idEditora`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `livro`
--

LOCK TABLES `livro` WRITE;
/*!40000 ALTER TABLE `livro` DISABLE KEYS */;
INSERT INTO `livro` VALUES (1,'1111',1,'Engenharia de Software','1990-01-01','teste'),(4,'44444',1,'Arquitetura de Software','1995-01-01',NULL);
/*!40000 ALTER TABLE `livro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pessoa`
--

DROP TABLE IF EXISTS `pessoa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pessoa` (
  `idPessoa` int(11) NOT NULL AUTO_INCREMENT,
  `cpf` varchar(11) NOT NULL,
  `nome` varchar(45) NOT NULL,
  `endereco` varchar(45) DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `cidade` varchar(45) DEFAULT NULL,
  `estado` varchar(2) DEFAULT NULL,
  `fone` varchar(12) DEFAULT NULL,
  `fone2` varchar(12) DEFAULT NULL,
  `tipoPessoa` enum('U','B','A') NOT NULL DEFAULT 'U',
  `dataNascimento` datetime NOT NULL,
  PRIMARY KEY (`idPessoa`),
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
-- Table structure for table `situacaolivro`
--

DROP TABLE IF EXISTS `situacaolivro`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `situacaolivro` (
  `idSituacaoLivro` char(1) NOT NULL,
  `situacao` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idSituacaoLivro`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `situacaolivro`
--

LOCK TABLES `situacaolivro` WRITE;
/*!40000 ALTER TABLE `situacaolivro` DISABLE KEYS */;
/*!40000 ALTER TABLE `situacaolivro` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'biblioteca'
--

--
-- Dumping routines for database 'biblioteca'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-05 23:56:48
