using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace Service
{

	public class EditoraService : IEditoraService
	{
		private readonly BibliotecaContext _context;

		public EditoraService(BibliotecaContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Insere um novo editora no base de dados
		/// </summary>
		/// <param name="editora">dados do editora</param>
		/// <returns></returns>
		public int Inserir(Editora editora)
		{
			_context.Add(editora);
			_context.SaveChanges();
			return editora.IdEditora;
		}

		/// <summary>
		/// Atualiza os dados do editora na base de dados
		/// </summary>
		/// <param name="editora">dados do editora</param>
		public void Editar(Editora editora)
		{
			_context.Update(editora);
			_context.SaveChanges();
		}

		/// <summary>
		/// Remove um editora da base de dados
		/// </summary>
		/// <param name="idEditora">identificado do editora</param>
		public void Remover(int idEditora)
		{
			var Editora = _context.Editora.Find(idEditora);
			_context.Editora.Remove(Editora);
			_context.SaveChanges();
		}

		/// <summary>
		/// Consulta genérica aos dados do editora
		/// </summary>
		/// <returns></returns>
		private IQueryable<Editora> GetQuery()
		{
			IQueryable<Editora> tb_editora = _context.Editora;
			var query = from editora in tb_editora
						select editora;
			return query;
		}

		/// <summary>
		/// Obtém todos os editoraes
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Editora> ObterTodos()
		{
			return GetQuery();
		}

		/// <summary>
		/// Obtém pelo identificado do editora
		/// </summary>
		/// <param name="idEditora"></param>
		/// <returns></returns>
		public Editora Obter(int idEditora)
		{
			IEnumerable<Editora> editoras = GetQuery().Where(editora => editora.IdEditora.Equals(idEditora));

			return editoras.ElementAtOrDefault(0);
		}

		/// <summary>
		/// Obtém editoraes que iniciam com o nome
		/// </summary>
		/// <param name="nome">nome a ser buscado</param>
		/// <returns></returns>
		public IEnumerable<Editora> ObterPorNome(string nome)
		{
			IEnumerable<Editora> editoras = GetQuery().Where(editora => editora.Nome.StartsWith(nome));
			return editoras;
		}

		public void ObterNomeEditoraNomeLivro()
		{
			var query = from editora in _context.Editora
						join livroModel in _context.Livro
						on editora.IdEditora equals livroModel.IdEditora
						select new 
						{
							NomeEditora = editora.Nome,
							NomeLivro = livroModel.Nome
						};
			// exemplo de como varrer objeto anônimo
			foreach(var editoraLivro in query)
			{
				Console.WriteLine(editoraLivro.NomeEditora);
				Console.WriteLine(editoraLivro.NomeLivro);
			}
		}



		public IEnumerable<Editora> ObterEditorasSPRS()
		{
			var query = from editora in _context.Editora
			where (editora.Estado.Equals("RS") ||
						editora.Estado.Equals("SP")) &&
						editora.Nome.ToUpper().Contains("EDITORA")
						select editora;
			return query;
		}


		public void ObterNomeCepEditora()
		{
			var query = from editora in _context.Editora
						select new 
						{
							NomeEditora = editora.Nome,
							CepEditora = editora.Cep,
						};

			foreach (var editoraAnonima in query)
			{
				Console.WriteLine(editoraAnonima.CepEditora);
				Console.WriteLine(editoraAnonima.NomeEditora);
			}
		}
	}

}
