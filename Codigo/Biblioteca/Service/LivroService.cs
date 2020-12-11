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
		/// Consulta genérica aos dados do livro
		/// </summary>
		/// <returns></returns>
		private IQueryable<LivroDTO> GetQuery()
		{
			IQueryable<Livro> tb_livro = _context.Livro;
			var query = from livro in tb_livro
						select new LivroDTO
						{
							Isbn = livro.Isbn,
							Nome = livro.Nome,
							NomeEditora = livro.IdEditoraNavigation.Nome
						};
			return query;
		}

		/// <summary>
		/// Obtém todos os livros
		/// </summary>
		/// <returns></returns>
		public IEnumerable<LivroDTO> ObterTodos()
		{
			return GetQuery();
		}


		public IEnumerable<LivroDTO> ObterDezPrimeiros()
		{
			return GetQuery().Take(10);
		}

		/// <summary>
		/// Obtém pelo identificado do livro
		/// </summary>
		/// <param name="idLivro"></param>
		/// <returns></returns>
		public LivroDTO Obter(string isbn)
		{
			IEnumerable<LivroDTO> livros = GetQuery().Where(livroModel => livroModel.Isbn.Equals(isbn));

			return livros.ElementAtOrDefault(0);
		}

		/// <summary>
		/// Obtém livroes que iniciam com o nome
		/// </summary>
		/// <param name="nome">nome a ser buscado</param>
		/// <returns></returns>
		public IEnumerable<LivroDTO> ObterPorNome(string nome)
		{
			IEnumerable<LivroDTO> livroes = GetQuery().Where(livroModel => livroModel.Nome.StartsWith(nome));
			return livroes;
		}

		/// <summary>
		/// Obtém todos os livros associados a uma editra
		/// </summary>
		/// <param name="nome"></param>
		/// <returns></returns>
		public IEnumerable<LivroDTO> ObterPorNomeEditora(string nomeEditora)
		{
			IQueryable<Livro> tb_livro = _context.Livro;
			var query = from livro in tb_livro
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
			IQueryable<Livro> tb_livro = _context.Livro;
			var query = from livro in tb_livro
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
			IQueryable<TbItemacervo> tb_itemAcervo = _context.TbItemacervo;
			var query = from itemAcervo in tb_itemAcervo
						group itemAcervo by itemAcervo.Isbn into g
						select new
						{
							Isbn = g.Key,
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
				IEnumerable<TbItemacervo> itensAcervo = tb_livro.TbItemacervo;
				foreach(var itemAcervo in itensAcervo)
				{
					System.Console.WriteLine(itemAcervo.IdItemAcervo);
					System.Console.WriteLine(itemAcervo.IdSituacaoLivroNavigation.Situacao);

				}
			}


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
							NumeroItensAcervo = livro.TbItemacervo.Count()
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
