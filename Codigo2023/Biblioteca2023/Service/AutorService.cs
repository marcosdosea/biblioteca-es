using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	/// <summary>
	/// Implementa serviços para manter dados do autor
	/// </summary>
    public class AutorService : IAutorService
	{
		private readonly BibliotecaContext context;

		public AutorService(BibliotecaContext context)
		{
			this.context = context;
		}


		/// <summary>
		/// Criar um novo autor na base de dados
		/// </summary>
		/// <param name="autor">dados do autor</param>
		/// <returns>id do autor</returns>
		public int Create(Autor autor)
		{
			context.Add(autor);
			context.SaveChanges();
			return autor.IdAutor;
		}

		/// <summary>
		/// Remover o autor da base de dados
		/// </summary>
		/// <param name="idAutor">id do autor</param>
		public void Delete(int id)
		{
			var autor = context.Autors.Find(id);
			context.Remove(autor);
			context.SaveChanges();
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

			context.Update(autor);
			context.SaveChanges();
		}

		/// <summary>
		/// Buscar um autor na base de dados
		/// </summary>
		/// <param name="idAutor">id autor</param>
		/// <returns>dados do autor</returns>
		public Autor Get(int id)
		{
			return context.Autors.Find(id);
		}

		/// <summary>
		/// Buscar todos os autores cadastrados
		/// </summary>
		/// <returns>lista de autores</returns>
		public IEnumerable<Autor> GetAll()
		{
			return context.Autors.AsNoTracking();
		}

		/// <summary>
		/// Buscar autores iniciando com o nome
		/// </summary>
		/// <param name="nome">nome do autor</param>
		/// <returns>lista de autores que inicia com o nome</returns>
		public IEnumerable<AutorDto> GetByNome(string nome)
		{
			var query = from autor in context.Autors
						where autor.Nome.StartsWith(nome)
						orderby autor.Nome
						select new AutorDto
						{
							IdAutor = autor.IdAutor,
							Nome = autor.Nome
						};
			return query;
		}
	}
}
