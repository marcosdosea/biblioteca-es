using Core;
using Core.DTO;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		/// Criar uma nova editora na base de dados 
		/// </summary>
		/// <param name="editora">dados da editora</param>
		/// <returns>id gerado</returns>
		public int Create(Editora editora)
		{
			_context.Add(editora);
			_context.SaveChanges();
			return editora.IdEditora;
		}

		/// <summary>
		/// Remover editora da base de dados
		/// </summary>
		/// <param name="idEditora">id a ser removido</param>
		public void Delete(int idEditora)
		{
			var _editora = _context.Editoras.Find(idEditora);
			_context.Remove(_editora);
			_context.SaveChanges();
		}

		/// <summary>
		/// Atualizar dados da editora
		/// </summary>
		/// <param name="editora">novos dados da editora</param>
		public void Edit(Editora editora)
		{
			_context.Update(editora);
			_context.SaveChanges();
		}

		/// <summary>
		/// Obter os dados de uma editora na base de dados
		/// </summary>
		/// <param name="idEditora">id da editora</param>
		/// <returns>Dados da editora</returns>
		public Editora Get(int idEditora)
		{
			return _context.Editoras.Find(idEditora);
		}

		/// <summary>
		/// Obter dados de todas as editoras
		/// </summary>
		/// <returns>lista de editoras</returns>
		public IEnumerable<Editora> GetAll()
		{
			return _context.Editoras.AsNoTracking();
		}

		/// <summary>
		/// Obter editoras que iniciam com o nome
		/// </summary>
		/// <param name="nome">nome da editora</param>
		/// <returns>lista de editoras</returns>
		public IEnumerable<Editora> GetByNome(string nome)
		{
			var query = from editora in _context.Editoras
						where editora.Nome.StartsWith(nome)
						orderby editora.Nome
						select editora;
			return query.AsNoTracking();
		}
	}
}
