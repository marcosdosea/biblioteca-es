using System.Collections.Generic;
using System.Linq;
using Models;
using Persistence;


namespace Services
{
    /// <summary>
    /// Gerencia todas as regras de negócio da entidade Livro
    /// </summary>
    
    public class GerenciadorLivro
    {
        private IUnitOfWork unitOfWork;
        private bool shared;

        /// <summary>
        /// Construtor pode ser acessado externamente e não compartilha contexto
        /// </summary>
        public GerenciadorLivro()
        {
            this.unitOfWork = new UnitOfWork();
            shared = false;
        }

        /// <summary>
        /// Construtor acessado apenas dentro do componentes service e permite compartilhar
        /// contexto com outras classes de negócio
        /// </summary>
        /// <param name="unitOfWork"></param>
        internal GerenciadorLivro(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            shared = true;
        }

        /// <summary>
        /// Insere um novo na base de dados
        /// </summary>
        /// <param name="livroModel">Dados do modelo</param>
        /// <returns>Chave identificante na base</returns>
        public void Inserir(Livro livroModel)
        {
            tb_livro livroE = new tb_livro();
            Atribuir(livroModel, livroE);
            unitOfWork.RepositorioLivro.Inserir(livroE);
            unitOfWork.Commit(shared);
        }

        /// <summary>
        /// Altera dados na base de dados
        /// </summary>
        /// <param name="livroModel"></param>
        public void Editar(Livro livroModel)
        {
            tb_livro livroE = new tb_livro(); 
            Atribuir(livroModel, livroE);
            unitOfWork.RepositorioLivro.Editar(livroE);
            unitOfWork.Commit(shared);
        }

        /// <summary>
        /// Remove da base de dados
        /// </summary>
        /// <param name="livroModel"></param>
        public void Remover(string isbn)
        {
            unitOfWork.RepositorioLivro.Remover(livro => livro.isbn.Equals(isbn));
            unitOfWork.Commit(shared);
        }


        /// <summary>
        /// Consulta padrão para retornar dados do livro como model
        /// </summary>
        /// <returns></returns>
        private IQueryable<Livro> GetQuery()
        {
            IQueryable<tb_livro> tb_livro = unitOfWork.RepositorioLivro.GetQueryable();
            var query = from livro in tb_livro 
                        select new Livro
                        {
                            Isbn = livro.isbn,
                            IdEditora = livro.idEditora,
                            DataPublicacao = livro.dataPublicacao,
                            Nome = livro.nome,
                            NomeEditora = livro.tb_editora.nome,
                            Resumo = livro.nome
                        };
            return query;
        }

        /// <summary>
        /// Obter todos as entidades cadastradas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Livro> ObterTodos()
        {
            return GetQuery();
        }

        /// <summary>
        /// Obtém um livro
        /// </summary>
        /// <param name="idLivro">Identificador do livro na base de dados</param>
        /// <returns>Livro model</returns>
        public Livro Obter(string isbn)
        {
            IEnumerable<Livro> livroes = GetQuery().Where(livroModel => livroModel.Isbn.Equals(isbn));
            return livroes.ElementAtOrDefault(0);
        }


        public IQueryable<Livro> ObterPorIdEditora(int idEditora)
        {
            return GetQuery().Where(livro => livro.IdEditora.Equals(idEditora)).OrderByDescending(livro => livro.Nome);
        }


        public IQueryable<Livro> ObterPorNomeEditora(string nomeEditora)
        {
            return GetQuery().Where(livro => livro.NomeEditora.StartsWith(nomeEditora)).OrderByDescending(livro => livro.Nome);
        }


        /// <summary>
        /// Consulta padrão para retornar dados do livro como model
        /// </summary>
        /// <returns></returns>
        public IQueryable ObterNumeroItensAcervoPorLivro()
        {
            IQueryable<tb_livro> tb_livro = unitOfWork.RepositorioLivro.GetQueryable();
            var query = from livro in tb_livro
                        select new
                        {
                            Isbn = livro.isbn,
                            IdEditora = livro.idEditora,
                            DataPublicacao = livro.dataPublicacao,
                            Nome = livro.nome,
                            NomeEditora = livro.tb_editora.nome,
                            Resumo = livro.nome,
                            NumeroItensAcervo = livro.tb_itemacervo.Count()
                        };
            return query;
        }

        

        /// <summary>
        /// Atribui dados do Livro Model para o Livro Entity
        /// </summary>
        /// <param name="livroModel">Objeto do modelo</param>
        /// <param name="livroE">Entity mapeada da base de dados</param>
        private void Atribuir(Livro livroModel, tb_livro livroE)
        {
            livroE.dataPublicacao = livroModel.DataPublicacao;
            livroE.idEditora = livroModel.IdEditora;
            livroE.isbn = livroModel.Isbn;
            livroE.nome = livroModel.Nome;
            livroE.resumo = livroModel.Resumo;
        }
    }
}
