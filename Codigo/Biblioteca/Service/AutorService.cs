using System.Collections.Generic;
using System.Linq;
using Core;

namespace Service
{

	public class AutorService : IAutorService
	{
		private readonly BibliotecaContext _context;

		public AutorService(BibliotecaContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Insere um novo autor no base de dados
		/// </summary>
		/// <param name="autorModel">dados do autor</param>
		/// <returns></returns>
		public int Inserir(Autor autor)
		{
			_context.Add(autor);
			_context.SaveChanges();
			return autor.IdAutor;
		}

		/// <summary>
		/// Atualiza os dados do autor na base de dados
		/// </summary>
		/// <param name="autorModel">dados do autor</param>
		public void Editar(Autor autor)
		{
			if (autor.AnoNascimento.Year < 1000)
				throw new ServiceException("O ano de nascimento de autor deve ser maior do que 1000. Favor informar nova data.");

			_context.Update(autor);
			_context.SaveChanges();
		}

		/// <summary>
		/// Remove um autor da base de dados
		/// </summary>
		/// <param name="idAutor">identificado do autor</param>
		public void Remover(int idAutor)
		{
			var _autor = _context.Autor.Find(idAutor);
			_context.Autor.Remove(_autor);
			_context.SaveChanges();
		}

		/// <summary>
		/// Consulta genérica aos dados do autor
		/// </summary>
		/// <returns></returns>
		private IQueryable<Autor> GetQuery()
		{
			IQueryable<Autor> tb_autor = _context.Autor;
			var query = from autor in tb_autor
						select autor;
			return query;
		}

		/// <summary>
		/// Obtém todos os autores
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Autor> ObterTodos()
		{
			return GetQuery();
		}
		/// <summary>
		/// REtorna o número de autores cadastrados
		/// </summary>
		/// <returns></returns>
		public int GetNumeroAutores()
		{
			return _context.Autor.Count();
		}

		/// <summary>
		/// Obtém os dados do primeiro autor cadastrado na base de dados.
		/// </summary>
		/// <returns></returns>
		public Autor ObterPrimeiroAutor()
		{
			Autor _tbautor = _context.Autor.FirstOrDefault();
			Autor autor = new Autor();
			if (_tbautor != null) { 
				autor.IdAutor = _tbautor.IdAutor;
				autor.AnoNascimento = _tbautor.AnoNascimento;
				autor.Nome = _tbautor.Nome;
			}
			return autor;
		}


		/// <summary>
		/// Obtém pelo identificado do autor
		/// </summary>
		/// <param name="idAutor"></param>
		/// <returns></returns>
		public Autor Obter(int idAutor)
		{
			IEnumerable<Autor> autores = GetQuery().Where(autorModel => autorModel.IdAutor.Equals(idAutor));

			return autores.ElementAtOrDefault(0);
		}

		/// <summary>
		/// Obtém autores que iniciam com o nome
		/// </summary>
		/// <param name="nome">nome a ser buscado</param>
		/// <returns></returns>
		public IEnumerable<Autor> ObterPorNome(string nome)
		{
			IEnumerable<Autor> autores = GetQuery()
				.Where(autorModel => autorModel.Nome.
				StartsWith(nome));
			return autores;
		}

		public IEnumerable<Autor> ObterPorNomeOtimizado(string nome)
		{
			IQueryable<Autor> tb_autor = _context.Autor;
			var query = from autor in tb_autor
						where nome.Contains(nome)
						select autor;
			return query;
		}

		/// <summary>
		/// Obtém autores ordenado de forma descendente
		/// </summary>
		/// <param name="nome"></param>
		/// <returns></returns>
		public IEnumerable<AutorDTO> ObterPorNomeOrdenadoDescending(string nome)
		{
			IQueryable<Autor> tb_autor = _context.Autor;
			var query = from autor in tb_autor
						where nome.StartsWith(nome)
						orderby autor.Nome descending
						select new AutorDTO
						{
							Nome = autor.Nome
						};
			return query;
		}
	}

}
