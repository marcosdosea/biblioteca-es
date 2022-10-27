using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class LivroService : ILivroService
	{
		private readonly BibliotecaContext _context;

		public LivroService(BibliotecaContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Cria um novo livro na base de dados
		/// </summary>
		/// <param name="livro">dados do livro</param>
		/// <returns>id do novo livro</returns>
		public int Create(Livro livro)
		{
			_context.Add(livro);
			_context.SaveChanges();
			return livro.IdLivro;
		}

		/// <summary>
		/// Remover dados de um livro da base de dados
		/// </summary>
		/// <param name="idLivro">id do livro</param>
		public void Delete(int idLivro)
		{
			var _livro = _context.Livros.Find(idLivro);
			_context.Remove(_livro);
			_context.SaveChanges();
		}

		/// <summary>
		/// Atualizar dados de um livro da base de dados
		/// </summary>
		/// <param name="livro">novos dados do livro</param>
		public void Edit(Livro livro)
		{
			_context.Update(livro);
			_context.SaveChanges();
		}

		/// <summary>
		/// Obter os dados de um livro da base de dados
		/// </summary>
		/// <param name="idLivro">id do livro</param>
		/// <returns>dados do livro</returns>
		public Livro Get(int idLivro)
		{
			return _context.Livros.Find(idLivro);
		}

		/// <summary>
		/// Obter dados de todos os livros da base de dados
		/// </summary>
		/// <returns>dados dos livros</returns>
		public IEnumerable<LivroDTO> GetAll()
		{
			var query = from livro in _context.Livros
						orderby livro.Nome descending
						select new LivroDTO
						{
							IdLivro = livro.IdLivro,
							Nome = livro.Nome,
							Isbn = livro.Isbn,
							NomeEditora = livro.IdEditoraNavigation.Nome
						};
			return query;
		}


		public IEnumerable<Autor> GetAutoresByLivro(int idLivro)
		{
			var livro = _context.Livros.Where(l => l.IdLivro == idLivro).FirstOrDefault();
			if (livro != null)
				return livro.Autorlivros.Select(autorlivros => autorlivros.IdAutorNavigation);
			return null;
		}



		/// <summary>
		/// Obter dados dos livros ordenado pelo nome que iniciam com um nome
		/// </summary>
		/// <param name="nome">nome a ser buscado</param>
		/// <returns>lista de livros</returns>
		public IEnumerable<LivroDTO> GetByNome(string nome)
		{
			var query = from livro in _context.Livros
						where livro.Nome.StartsWith(nome)
						orderby livro.Nome
						select new LivroDTO
						{
							IdLivro = livro.IdLivro,
							Nome = livro.Nome,
							Isbn = livro.Isbn,
							NomeEditora = livro.IdEditoraNavigation.Nome
						};
			return query;
		}
	}
}
