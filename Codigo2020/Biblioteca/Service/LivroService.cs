using Core;
using System.Collections.Generic;
using System.Linq;

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
		/// Insere um novo livro no base de dados
		/// </summary>
		/// <param name="livroModel">dados do livro</param>
		/// <returns></returns>
		public void Inserir(Livro livro)
		{
			_context.Add(livro);
			_context.SaveChanges();
		}

		/// <summary>
		/// Atualiza os dados do livro na base de dados
		/// </summary>
		/// <param name="livroModel">dados do livro</param>
		public void Editar(Livro livro)
		{
			_context.Update(livro);
			_context.SaveChanges();
		}

		/// <summary>
		/// Remove um livro da base de dados
		/// </summary>
		/// <param name="idLivro">identificado do livro</param>
		public void Remover(int idLivro)
		{
			var _livro = _context.Livro.Find(idLivro);
			_context.Livro.Remove(_livro);
			_context.SaveChanges();
		}

		/// <summary>
		/// Obtém todos os livros
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Livro> ObterTodos()
		{
			return _context.Livro.ToList();
		}


		public IEnumerable<Livro> ObterDezPrimeiros()
		{
			return _context.Livro.Take(10).ToList();
		}

		/// <summary>
		/// Obtém pelo identificado do livro
		/// </summary>
		/// <param name="idLivro"></param>
		/// <returns></returns>
		public Livro Obter(int idLivro)
		{
			var query = from livro in _context.Livro
						where livro.IdLivro.Equals(idLivro)
						select livro;
			return query.FirstOrDefault();
		}

		/// <summary>
		/// Obtém livroes que iniciam com o nome
		/// </summary>
		/// <param name="nome">nome a ser buscado</param>
		/// <returns></returns>
		public IEnumerable<LivroDTO> ObterPorNome(string nome)
		{
			var query = from livro in _context.Livro
						where livro.Nome.StartsWith(nome)
						select new LivroDTO
						{
							Isbn = livro.Isbn,
							Nome = livro.Nome,
							NomeEditora = livro.IdEditoraNavigation.Nome
						};
			return query;
		}

		/// <summary>
		/// Obtém todos os livros associados a uma editra
		/// </summary>
		/// <param name="nome"></param>
		/// <returns></returns>
		public IEnumerable<LivroDTO> ObterPorNomeEditora(string nomeEditora)
		{
			var query = from livro in _context.Livro
						where livro.IdEditoraNavigation.Nome.Equals(nomeEditora)
						select new LivroDTO
						{
							Isbn = livro.Isbn,
							Nome = livro.Nome,
							NomeEditora = livro.IdEditoraNavigation.Nome
						};
			return query;
		}

		/// <summary>
		/// Obter livros
		/// </summary>
		/// <param name="nomeLivro"></param>
		/// <returns></returns>
		public IEnumerable<LivroDTO> ObterOrdenadoPorNome(string nomeLivro)
		{
			var query = from livro in _context.Livro
						where livro.Nome.StartsWith(nomeLivro)
						orderby livro.Nome
						select new LivroDTO
						{
							Isbn = livro.Isbn,
							Nome = livro.Nome,
							NomeEditora = livro.IdEditoraNavigation.Nome
						};
			return query;
		}

		public void ObterLivroMaxExemplares()
		{
			var query = from itemAcervo in _context.Itemacervo
						group itemAcervo by itemAcervo.IdLivro into g
						select new
						{
							IdLivro = g.Key,
							CountLivros = g.Count()
						};
			var itemMaximo = query.Max(item => item.CountLivros);
		}




		public void ObterItensAcervoPorLivro(string isbnLivro)
		{
			Livro tb_livro = _context.Livro.
				Where(livro => livro.Isbn.Equals(isbnLivro)).FirstOrDefault();

			if (tb_livro != null)
			{
				IEnumerable<Itemacervo> itensAcervo = tb_livro.Itemacervo;
				foreach(var itemAcervo in itensAcervo)
				{
					System.Console.WriteLine(itemAcervo.IdItemAcervo);
					System.Console.WriteLine(itemAcervo.IdSituacaoLivroNavigation.Situacao);

				}
			}
		}

		/// <summary>
		/// Retorna número de itens do acervo por editora
		/// </summary>
		/// <returns></returns>
		public IEnumerable<LivroPorEditoraDTO> ObterNumeroLivrosPorEditora()
		{
			var query = from livro in _context.Livro
						group livro by new
						{
							livro.IdEditora,
							livro.IdEditoraNavigation.Nome
						}
						into g
						select new LivroPorEditoraDTO
						{
							IdEditora = g.Key.IdEditora,
							NomeEditora = g.Key.Nome,
							CountLivros = g.Count()
						};
			return query.ToList();
		}

		/// <summary>
		/// Obtém o número os itens de acervo de cada livro
		/// </summary>
		public void ObterNumeroItensAcervoPorLivro()
		{
			IQueryable<Livro> tb_livro = _context.Livro;
			var query = from livro in tb_livro
						orderby livro.Nome
						select new
						{
							IsbnLivro = livro.Isbn,
							NomeLivro = livro.Nome,
							NumeroItensAcervo = livro.Itemacervo.Count()
						};

			foreach (var itemAcervo in query)
			{
				System.Console.WriteLine(itemAcervo.IsbnLivro);
				System.Console.WriteLine(itemAcervo.NomeLivro);
				System.Console.WriteLine(itemAcervo.NumeroItensAcervo);
			}

		}
	}

}
