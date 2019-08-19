using Data;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{

	public class GerenciadorAutor : IGerenciadorAutor
	{
		private readonly BibliotecaContext _context;

		public GerenciadorAutor(BibliotecaContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Insere um novo autor no base de dados
		/// </summary>
		/// <param name="autorModel">dados do autor</param>
		/// <returns></returns>
		public int Inserir(Autor autorModel)
		{
			TbAutor _tbAutor = new TbAutor();
			_tbAutor.IdAutor = autorModel.IdAutor;
			_tbAutor.Nome = autorModel.Nome;
			_tbAutor.AnoNascimento = autorModel.AnoNascimento;

			_context.Add(_tbAutor);
			_context.SaveChanges();
			return _tbAutor.IdAutor;
		}

		/// <summary>
		/// Atualiza os dados do autor na base de dados
		/// </summary>
		/// <param name="autorModel">dados do autor</param>
		public void Editar(Autor autorModel)
		{
			if (autorModel.AnoNascimento.Year < 1000)
				throw new ServiceException("O ano de nascimento de autor deve ser maior do que 1000. Favor informar nova data.");

			TbAutor tbAutor = new TbAutor();
			Atribuir(autorModel, tbAutor);
			_context.Update(tbAutor);
			_context.SaveChanges();
		}

		/// <summary>
		/// Remove um autor da base de dados
		/// </summary>
		/// <param name="idAutor">identificado do autor</param>
		public void Remover(int idAutor)
		{
			var tbAutor = _context.TbAutor.Find(idAutor);
			_context.TbAutor.Remove(tbAutor);
			_context.SaveChanges();
		}

		/// <summary>
		/// Consulta genérica aos dados do autor
		/// </summary>
		/// <returns></returns>
		private IQueryable<Autor> GetQuery()
		{
			IQueryable<TbAutor> tb_autor = _context.TbAutor;
			var query = from autor in tb_autor
						select new Autor
						{
							IdAutor = autor.IdAutor,
							Nome = autor.Nome,
							AnoNascimento = autor.AnoNascimento
						};
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
			return _context.TbAutor.Count();
		}

		/// <summary>
		/// Obtém os dados do primeiro autor cadastrado na base de dados.
		/// </summary>
		/// <returns></returns>
		public Autor ObterPrimeiroAutor()
		{
			TbAutor _tbautor = _context.TbAutor.FirstOrDefault();
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
			IQueryable<TbAutor> tb_autor = _context.TbAutor;
			var query = from autor in tb_autor
						where nome.Contains(nome)
						select new Autor
						{
							IdAutor = autor.IdAutor,
							Nome = autor.Nome,
							AnoNascimento = autor.AnoNascimento
						};
			return query;
		}

		/// <summary>
		/// Obtém autores ordenado de forma descendente
		/// </summary>
		/// <param name="nome"></param>
		/// <returns></returns>
		public IEnumerable<Autor> ObterPorNomeOrdenadoDescending(string nome)
		{
			IQueryable<TbAutor> tb_autor = _context.TbAutor;
			var query = from autor in tb_autor
						where nome.StartsWith(nome)
						orderby autor.Nome descending
						select new Autor
						{
							IdAutor = autor.IdAutor,
							Nome = autor.Nome,
							AnoNascimento = autor.AnoNascimento
						};
			return query;
		}






		/// <summary>
		/// Atribui dados entre objetos do model e entity
		/// </summary>
		/// <param name="autorModel">objeto model</param>
		/// <param name="tbAutor">objeto entity</param>
		private void Atribuir(Autor autorModel, TbAutor tbAutor)
		{
			tbAutor.IdAutor = autorModel.IdAutor;
			tbAutor.Nome = autorModel.Nome;
			tbAutor.AnoNascimento = autorModel.AnoNascimento;
		}

	}

}
