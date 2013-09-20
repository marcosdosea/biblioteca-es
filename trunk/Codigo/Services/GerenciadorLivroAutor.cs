using System.Collections.Generic;
using System.Linq;
using Models;
using Persistence;


namespace Services
{
    /// <summary>
    /// Gerencia todas as regras de negócio da entidade Livro
    /// </summary>
    
    public class GerenciadorLivroAutor
    {
        private IUnitOfWork unitOfWork;
        private bool shared;

        /// <summary>
        /// Construtor pode ser acessado externamente e não compartilha contexto
        /// </summary>
        public GerenciadorLivroAutor()
        {
            this.unitOfWork = new UnitOfWork();
            shared = false;
        }

        /// <summary>
        /// Construtor acessado apenas dentro do componentes service e permite compartilhar
        /// contexto com outras classes de negócio
        /// </summary>
        /// <param name="unitOfWork"></param>
        internal GerenciadorLivroAutor(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            shared = true;
        }

        /// <summary>
        /// Insere um novo na base de dados
        /// </summary>
        /// <param name="livroModel">Dados do modelo</param>
        /// <returns>Chave identificante na base</returns>
        public void Inserir(string isbn, int idAutor)
        {
            tb_autor autorE = new tb_autor() { idAutor = idAutor };
            tb_livro livroE = new tb_livro() { isbn = isbn };
            livroE.tb_autor.Add(autorE);
            unitOfWork.RepositorioLivro.Editar(livroE);
            unitOfWork.Commit(shared);
        }

        /// <summary>
        /// Remove da base de dados
        /// </summary>
        /// <param name="livroModel"></param>
        public void Remover(string isbn, int idAutor)
        {
            tb_livro livroE = unitOfWork.RepositorioLivro.ObterEntidade(livro => livro.isbn.Equals(isbn));
            tb_autor autorE = new tb_autor() { idAutor = idAutor };
            livroE.tb_autor.Remove(autorE);
            unitOfWork.Commit(shared);
        }


        /// <summary>
        /// Obter autores de um dado livro
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public IEnumerable<Autor> ObterAutoresPorLivro(string isbn)
        {
            tb_livro livroE = unitOfWork.RepositorioLivro.GetQueryable().Where(livro => livro.isbn.Equals(isbn)).SingleOrDefault();
            var query = from autor in livroE.tb_autor
                        select new Autor
                        {
                            AnoNascimento = autor.anoNascimento,
                            Codigo = autor.idAutor,
                            Nome = autor.NomeAutor
                        };
            return query;
        }
    }
}
