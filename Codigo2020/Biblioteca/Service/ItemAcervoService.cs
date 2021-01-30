using Core;
using System.Linq;
using System.Collections.Generic;

namespace Service
{
	public class ItemAcervoService : IItemAcervoService
	{
		private readonly BibliotecaContext _context;
		public ItemAcervoService(BibliotecaContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Insere um novo item do acervo
		/// </summary>
		/// <param name="itemAcervo"></param>
		/// <returns></returns>
		public int Inserir(Itemacervo itemAcervo)
		{
			_context.Add(itemAcervo);
			_context.SaveChanges();
			return itemAcervo.IdItemAcervo;
		}

		/// <summary>
		/// Edita dados do item de acervo
		/// </summary>
		/// <param name="itemAcervo"></param>
		public void Editar(Itemacervo itemAcervo)
		{
			_context.Update(itemAcervo);
			_context.SaveChanges();
		}

		/// <summary>
		/// Obter todos os dados do item acervo
		/// </summary>
		/// <param name="idItemAcervo">id do itemacervo</param>
		/// <returns></returns>
		public Itemacervo Obter(int idItemAcervo)
		{
			var query = from itemacervo in _context.Itemacervo
						where itemacervo.IdItemAcervo.Equals(idItemAcervo)
						select itemacervo;
			return query.FirstOrDefault();
		}

		/// <summary>
		/// Obtém todos os itens do acervo
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Itemacervo> ObterTodos()
		{
			var query = from itemacervo in _context.Itemacervo
						select itemacervo;
			return query;
		}

		/// <summary>
		/// Remove um item do acervo
		/// </summary>
		/// <param name="idItemAcervo">id itemacervo a ser removido</param>
		public void Remover(int idItemAcervo)
		{
			var _itemAcervo = _context.Itemacervo.Find(idItemAcervo);
			_context.Itemacervo.Remove(_itemAcervo);
			_context.SaveChanges();
		}

	}
}
