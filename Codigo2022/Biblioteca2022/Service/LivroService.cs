using BibliotecaWEB.Models;
using Core;
using Core.DTO;
using Core.Service;
using LinqKit;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
			return new List<Autor>();
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

		public IEnumerable<LivroDTO> GetByPage(DatatableDTO model, out int filteredResultsCount, out int totalResultsCount)
		{
			var searchBy = (model.search != null) ? model.search.value : null;
			var take = model.length;
			var skip = model.start;


			// if we have an empty search then just order the results by Id ascending
			var sortBy = "Id";
			var sortDir = true;

			if (model.order != null)
			{
				// in this example we just default sort on the 1st column
				sortBy = model.columns[model.order[0].column].data;
				sortDir = model.order[0].dir.ToLower() == "asc";
			}
			var whereClause = BuildDynamicWhereClause(searchBy);

			var query = _context.Livros
				   .Where(whereClause)
				   .Select(livro => new LivroDTO
				   {
					   IdLivro = livro.IdLivro,
					   Nome = livro.Nome,
					   Isbn = livro.Isbn,
					   NomeEditora = livro.IdEditoraNavigation.Nome
				   })
				   .OrderBy(sortBy, sortDir)
				   .Skip(skip)
				   .Take(take)
				   .ToList();

			// now just get the count of items (without the skip and take) - eg how many could be returned with filtering
			filteredResultsCount = _context.Livros.Where(whereClause).Count();
			totalResultsCount = _context.Livros.Count();

			return query;
		}

		private Expression<Func<Livro, bool>> BuildDynamicWhereClause(string? searchValue)
		{
			// simple method to dynamically plugin a where clause
			var predicate = PredicateBuilder.New<Livro>(true); // true -where(true) return all
			if (!String.IsNullOrWhiteSpace(searchValue))
			{
				// as we only have 2 cols allow the user type in name 'firstname lastname' then use the list to search the first and last name of dbase
				var searchTerms = searchValue.Split(' ').ToList().ConvertAll(x => x.ToLower());

				predicate = predicate.Or(s => searchTerms.Any(srch => s.Nome.ToLower().Contains(srch)));
				predicate = predicate.Or(s => searchTerms.Any(srch => s.Isbn.ToLower().Contains(srch)));
				predicate = predicate.Or(s => searchTerms.Any(srch => s.IdEditoraNavigation.Nome.ToLower().Contains(srch)));
			}
			return predicate;
		}
	}
}
