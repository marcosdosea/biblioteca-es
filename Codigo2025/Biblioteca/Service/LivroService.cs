using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class LivroService : ILivroService
    {
        private readonly BibliotecaContext context;

        public LivroService(BibliotecaContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Cria um novo livro na base de dados
        /// </summary>
        /// <param name="livro">dados do livro</param>
        /// <returns>id do novo livro</returns>
        public uint Create(Livro livro)
        {
            context.Add(livro);
            context.SaveChanges();
            return livro.Id;
        }

        /// <summary>
        /// Remover dados de um livro da base de dados
        /// </summary>
        /// <param name="id">id do livro</param>
        public void Delete(uint id)
        {
            var livro = context.Livros.Find(id);
            if (livro != null)
            {
                context.Remove(livro);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Atualizar dados de um livro da base de dados
        /// </summary>
        /// <param name="livro">novos dados do livro</param>
        public void Edit(Livro livro)
        {
            context.Update(livro);
            context.SaveChanges();
        }

        /// <summary>
        /// Obter os dados de um livro da base de dados
        /// </summary>
        /// <param name="id">id do livro</param>
        /// <returns>dados do livro</returns>
        public Livro? Get(uint id)
        {
            return context.Livros.Find(id);
        }

        public IEnumerable<LivroDto> GetLivroDTO()
        {
            var query = from livro in context.Livros
                        select new LivroDto
                        {
                            Id = livro.Id,
                            Isbn = livro.Isbn,
                            Nome = livro.Nome,
                            NomeEditora = livro.IdEditoraNavigation.Nome
                        };
            return query.AsNoTracking();
        }




        /// <summary>
        /// Obter dados de todos os livros da base de dados
        /// </summary>
        /// <returns>dados dos livros</returns>
        public IEnumerable<LivroDto> GetAll()
        {
            var query = from livro in context.Livros
                        orderby livro.Nome descending
                        select new LivroDto
                        {
                            Id = livro.Id,
                            Nome = livro.Nome,
                            Isbn = livro.Isbn,
                            NomeEditora = livro.IdEditoraNavigation.Nome
                        };
            return query;
        }


        public IEnumerable<Autor> GetAutoresByLivro(int idLivro)
        {
            var livro = context.Livros.Where(l => l.Id == idLivro).FirstOrDefault();
            if (livro != null)
                return livro.IdAutors;
            return [];
        }

        public IEnumerable<Livro> GetLivrosByNomeEditora(string nome)
        {
            var query = from livro in context.Livros
                        where livro.IdEditoraNavigation.Nome.StartsWith(nome)
                        select livro;
            return query;
        }

        /// <summary>
        /// Obter dados dos livros ordenado pelo nome que iniciam com um nome
        /// </summary>
        /// <param name="nome">nome a ser buscado</param>
        /// <returns>lista de livros</returns>
        public IEnumerable<LivroDto> GetByNome(string nome)
        {
            var query = from livro in context.Livros
                        where livro.Nome.StartsWith(nome)
                        orderby livro.Nome
                        select new LivroDto
                        {
                            Id = livro.Id,
                            Nome = livro.Nome,
                            Isbn = livro.Isbn,
                            NomeEditora = livro.IdEditoraNavigation.Nome
                        };
            return query;
        }
    }
}
