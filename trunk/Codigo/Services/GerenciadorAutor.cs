using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using Persistence;
using Models;


namespace Services
{
    /// <summary>
    /// Gerencia todas as regras de negócio da entidade Autor
    /// </summary>
    
    public class GerenciadorAutor
    {
        private IUnitOfWork unitOfWork;
        private bool shared;

        /// <summary>
        /// Construtor pode ser acessado externamente e não compartilha contexto
        /// </summary>
        public GerenciadorAutor()
        {
            this.unitOfWork = new UnitOfWork();
            shared = false;
        }

        /// <summary>
        /// Construtor acessado apenas dentro do componentes service e permite compartilhar
        /// contexto com outras classes de negócio
        /// </summary>
        /// <param name="unitOfWork"></param>
        internal GerenciadorAutor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            shared = true;
        }

        /// <summary>
        /// Insere um novo na base de dados
        /// </summary>
        /// <param name="autorModel">Dados do modelo</param>
        /// <returns>Chave identificante na base</returns>
        public int Inserir(Autor autorModel)
        {
            tb_autor autorE = new tb_autor();
            Atribuir(autorModel, autorE);
            unitOfWork.RepositorioAutor.Inserir(autorE);
            unitOfWork.Commit(shared);
            return autorE.idAutor;
        }

        /// <summary>
        /// Altera dados na base de dados
        /// </summary>
        /// <param name="autorModel"></param>
        public void Editar(Autor autorModel)
        {
            tb_autor autorE = new tb_autor(); 
            Atribuir(autorModel, autorE);
            unitOfWork.RepositorioAutor.Editar(autorE);
            unitOfWork.Commit(shared);
        }

        /// <summary>
        /// Remove da base de dados
        /// </summary>
        /// <param name="autorModel"></param>
        public void Remover(int idAutor)
        {
            unitOfWork.RepositorioAutor.Remover(autor => autor.idAutor.Equals(idAutor));
            unitOfWork.Commit(shared);
        }


        /// <summary>
        /// Consulta padrão para retornar dados do autor como model
        /// </summary>
        /// <returns></returns>
        private IQueryable<Autor> GetQuery()
        {
            IQueryable<tb_autor> tb_autor = unitOfWork.RepositorioAutor.GetQueryable();
            var query = from autor in tb_autor 
                        select new Autor
                        {
                            Codigo = autor.idAutor,
                            Nome = autor.NomeAutor,
                            AnoNascimento = autor.anoNascimento
                        };
            return query;
        }

        /// <summary>
        /// Obter todos as entidades cadastradas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Autor> ObterTodos()
        {
            return GetQuery();
        }

        
        /// <summary>
        /// Obtém um autor
        /// </summary>
        /// <param name="idAutor">Identificador do autor na base de dados</param>
        /// <returns>Autor model</returns>
        public Autor Obter(int idAutor)
        {
            IEnumerable<Autor> autores = GetQuery().Where(autorModel => autorModel.Codigo.Equals(idAutor));

            return autores.ElementAtOrDefault(0);
        }


        /// <summary>
        /// Obtém um autor pelo nome
        /// </summary>
        /// <param name="nome">Nome do autor que será buscado base de dados</param>
        /// <returns>Autor model</returns>
        public IEnumerable<Autor> ObterPorNome(string nome)
        {
            IEnumerable<Autor> autores = GetQuery().Where(autorModel => autorModel.Nome.StartsWith(nome));
            return autores;
        }

        /// <summary>
        /// Atribui dados do Autor Model para o Autor Entity
        /// </summary>
        /// <param name="autorModel">Objeto do modelo</param>
        /// <param name="autorE">Entity mapeada da base de dados</param>
        private void Atribuir(Autor autorModel, tb_autor autorE)
        {
            autorE.idAutor = autorModel.Codigo;
            autorE.NomeAutor = autorModel.Nome;
            autorE.anoNascimento = autorModel.AnoNascimento;
        }
    }
}
