using Data;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{

	public class GerenciadorEditora : IGerenciadorEditora
	{
		private readonly BibliotecaContext _context;

		public GerenciadorEditora(BibliotecaContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Insere um novo editora no base de dados
		/// </summary>
		/// <param name="editoraModel">dados do editora</param>
		/// <returns></returns>
		public int Inserir(Editora editoraModel)
		{
			TbEditora _tbEditora = new TbEditora();
			_tbEditora.IdEditora = editoraModel.IdEditora;
			_tbEditora.Nome = editoraModel.Nome;
			_tbEditora.Numero = editoraModel.Numero;
			_tbEditora.Bairro = editoraModel.Bairro;
			_tbEditora.Cep = editoraModel.Cep;
			_tbEditora.Cidade = editoraModel.Cidade;
			_tbEditora.Estado = editoraModel.Estado;
			_tbEditora.Rua = editoraModel.Rua;
			_context.Add(_tbEditora);
			_context.SaveChanges();
			return _tbEditora.IdEditora;
		}

		/// <summary>
		/// Atualiza os dados do editora na base de dados
		/// </summary>
		/// <param name="editoraModel">dados do editora</param>
		public void Editar(Editora editoraModel)
		{
			TbEditora tbEditora = new TbEditora();
			Atribuir(editoraModel, tbEditora);
			_context.Update(tbEditora);
			_context.SaveChanges();
		}

		/// <summary>
		/// Remove um editora da base de dados
		/// </summary>
		/// <param name="idEditora">identificado do editora</param>
		public void Remover(int idEditora)
		{
			var tbEditora = _context.TbEditora.Find(idEditora);
			_context.TbEditora.Remove(tbEditora);
			_context.SaveChanges();
		}

		/// <summary>
		/// Consulta genérica aos dados do editora
		/// </summary>
		/// <returns></returns>
		private IQueryable<Editora> GetQuery()
		{
			IQueryable<TbEditora> tb_editora = _context.TbEditora;
			var query = from editora in tb_editora
						select new Editora
						{
							IdEditora = editora.IdEditora,
							Nome = editora.Nome,
							Bairro = editora.Bairro,
							Cep = editora.Cep,
							Cidade = editora.Cidade,
							Estado = editora.Estado,
							Numero = editora.Numero,
							Rua = editora.Rua
						};
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
			IEnumerable<Editora> editoras = GetQuery().Where(editoraModel => editoraModel.IdEditora.Equals(idEditora));

			return editoras.ElementAtOrDefault(0);
		}

		/// <summary>
		/// Obtém editoraes que iniciam com o nome
		/// </summary>
		/// <param name="nome">nome a ser buscado</param>
		/// <returns></returns>
		public IEnumerable<Editora> ObterPorNome(string nome)
		{
			IEnumerable<Editora> editoras = GetQuery().Where(editoraModel => editoraModel.Nome.StartsWith(nome));
			return editoras;
		}

		/// <summary>
		/// Atribui dados entre objetos do model e entity
		/// </summary>
		/// <param name="editoraModel">objeto model</param>
		/// <param name="tbEditora">objeto entity</param>
		private void Atribuir(Editora editoraModel, TbEditora tbEditora)
		{
			tbEditora.IdEditora = editoraModel.IdEditora;
			tbEditora.Nome = editoraModel.Nome;
			tbEditora.Bairro = editoraModel.Bairro;
			tbEditora.Cep = editoraModel.Cep;
			tbEditora.Cidade = editoraModel.Cidade;
			tbEditora.Estado = editoraModel.Estado;
			tbEditora.Numero = editoraModel.Numero;
			tbEditora.Rua = editoraModel.Rua;
		}

	}

}
