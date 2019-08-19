using Data;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{

	public class GerenciadorLivro : IGerenciadorLivro
	{
		private readonly BibliotecaContext _context;

		public GerenciadorLivro(BibliotecaContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Insere um novo livro no base de dados
		/// </summary>
		/// <param name="livroModel">dados do livro</param>
		/// <returns></returns>
		public void Inserir(Livro livroModel)
		{
			TbLivro _tbLivro = new TbLivro();
			_tbLivro.Isbn = livroModel.Isbn;
			_tbLivro.Nome = livroModel.Nome;
			_tbLivro.DataPublicacao = livroModel.DataPublicacao;
			_tbLivro.IdEditora = livroModel.IdEditora;
			_tbLivro.Resumo = livroModel.Resumo;

			_context.Add(_tbLivro);
			_context.SaveChanges();
		}

		/// <summary>
		/// Atualiza os dados do livro na base de dados
		/// </summary>
		/// <param name="livroModel">dados do livro</param>
		public void Editar(Livro livroModel)
		{
			TbLivro tbLivro = new TbLivro();
			Atribuir(livroModel, tbLivro);
			_context.Update(tbLivro);
			_context.SaveChanges();
		}

		/// <summary>
		/// Remove um livro da base de dados
		/// </summary>
		/// <param name="idLivro">identificado do livro</param>
		public void Remover(int idLivro)
		{
			var tbLivro = _context.TbLivro.Find(idLivro);
			_context.TbLivro.Remove(tbLivro);
			_context.SaveChanges();
		}

		/// <summary>
		/// Consulta genérica aos dados do livro
		/// </summary>
		/// <returns></returns>
		private IQueryable<Livro> GetQuery()
		{
			IQueryable<TbLivro> tb_livro = _context.TbLivro;
			var query = from livro in tb_livro
						select new Livro
						{
							Isbn = livro.Isbn,
							Nome = livro.Nome,
							DataPublicacao = livro.DataPublicacao,
							IdEditora = livro.IdEditora,
							Resumo = livro.Resumo,
							NomeEditora = livro.IdEditoraNavigation.Nome
						};
			return query;
		}

		/// <summary>
		/// Obtém todos os livros
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Livro> ObterTodos()
		{
			return GetQuery();
		}


		public IEnumerable<Livro> ObterDezPrimeiros()
		{
			return GetQuery().Take(10);
		}

		/// <summary>
		/// Obtém pelo identificado do livro
		/// </summary>
		/// <param name="idLivro"></param>
		/// <returns></returns>
		public Livro Obter(int idLivro)
		{
			IEnumerable<Livro> livros = GetQuery().Where(livroModel => livroModel.Isbn.Equals(idLivro.ToString()));

			return livros.ElementAtOrDefault(0);
		}

		/// <summary>
		/// Obtém livroes que iniciam com o nome
		/// </summary>
		/// <param name="nome">nome a ser buscado</param>
		/// <returns></returns>
		public IEnumerable<Livro> ObterPorNome(string nome)
		{
			IEnumerable<Livro> livroes = GetQuery().Where(livroModel => livroModel.Nome.StartsWith(nome));
			return livroes;
		}

		/// <summary>
		/// Obtém todos os livros associados a uma editra
		/// </summary>
		/// <param name="nome"></param>
		/// <returns></returns>
		public IEnumerable<Livro> ObterPorNomeEditora(string nomeEditora)
		{
			IQueryable<TbLivro> tb_livro = _context.TbLivro;
			var query = from livro in tb_livro
						where livro.IdEditoraNavigation.Nome.Equals(nomeEditora)
						select new Livro
						{
							Isbn = livro.Isbn,
							Nome = livro.Nome,
							DataPublicacao = livro.DataPublicacao,
							IdEditora = livro.IdEditora,
							Resumo = livro.Resumo,
							NomeEditora = livro.IdEditoraNavigation.Nome
						};
			return query;
		}

		/// <summary>
		/// Obter livros
		/// </summary>
		/// <param name="nomeLivro"></param>
		/// <returns></returns>
		public IEnumerable<Livro> ObterOrdenadoPorNome(string nomeLivro)
		{
			IQueryable<TbLivro> tb_livro = _context.TbLivro;
			var query = from livro in tb_livro
						where livro.Nome.StartsWith(nomeLivro)
						orderby livro.Nome
						select new Livro
						{
							Isbn = livro.Isbn,
							Nome = livro.Nome,
							DataPublicacao = livro.DataPublicacao,
							IdEditora = livro.IdEditora,
							Resumo = livro.Resumo,
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
			TbLivro tb_livro = _context.TbLivro.
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
			IQueryable<TbLivro> tb_livro = _context.TbLivro;
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


		/// <summary>
		/// Atribui dados entre objetos do model e entity
		/// </summary>
		/// <param name="livroModel">objeto model</param>
		/// <param name="tbLivro">objeto entity</param>
		private void Atribuir(Livro livroModel, TbLivro tbLivro)
		{
			tbLivro.Isbn = livroModel.Isbn;
			tbLivro.Nome = livroModel.Nome;
			tbLivro.DataPublicacao = livroModel.DataPublicacao;
			tbLivro.IdEditora = livroModel.IdEditora;
			tbLivro.Resumo = livroModel.Resumo;
		}

	}

}
