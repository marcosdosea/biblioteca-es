using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

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
		/// Criar um novo autor na base de dados
		/// </summary>
		/// <param name="autor">dados do autor</param>
		/// <returns>id do autor</returns>
		public int Create(Autor autor)
		{
			_context.Add(autor);
			_context.SaveChanges();
			return autor.IdAutor;
		}

		/// <summary>
		/// Remover o autor da base de dados
		/// </summary>
		/// <param name="idAutor">id do autor</param>
		public void Delete(int idAutor)
		{
			var _autor = _context.Autors.Find(idAutor);
			_context.Remove(_autor);
			_context.SaveChanges();
		}

		/// <summary>
		/// Editar dados do autor na base de dados
		/// </summary>
		/// <param name="autor"></param>
		/// <exception cref="ServiceException"></exception>
		public void Edit(Autor autor)
		{
			if (autor.AnoNascimento.Year < 1000)
				throw new ServiceException("O ano de nascimento de autor deve ser maior do que 1000. Favor informar nova data.");

			_context.Update(autor);
			_context.SaveChanges();
		}

		/// <summary>
		/// Buscar um autor na base de dados
		/// </summary>
		/// <param name="idAutor">id autor</param>
		/// <returns>dados do autor</returns>
		public Autor Get(int idAutor)
		{
			return _context.Autors.Find(idAutor);
		}

		/// <summary>
		/// Buscar todos os autores cadastrados
		/// </summary>
		/// <returns>lista de autores</returns>
		public IEnumerable<Autor> GetAll()
		{
			return _context.Autors.AsNoTracking();
		}

		/// <summary>
		/// Buscar autores iniciando com o nome
		/// </summary>
		/// <param name="nome">nome do autor</param>
		/// <returns>lista de autores que inicia com o nome</returns>
		public IEnumerable<AutorDTO> GetByNome(string nome)
		{
			var query = from autor in _context.Autors
						where autor.Nome.StartsWith(nome)
						orderby autor.Nome
						select new AutorDTO
						{
							IdAutor = autor.IdAutor,
							Nome = nome
						};
			return query;
		}
	}
}
