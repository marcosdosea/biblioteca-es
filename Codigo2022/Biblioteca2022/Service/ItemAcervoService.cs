using Core;
using Core.Service;

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
		/// 
		/// </summary>
		/// <param name="itemAcervo"></param>
		/// <returns></returns>
		public int Create(Itemacervo itemAcervo)
		{
			_context.Add(itemAcervo);
			_context.SaveChanges();
			return itemAcervo.IdItemAcervo;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="idItemAcervo"></param>
		public void Delete(int idItemAcervo)
		{
			var _itemAcervo = _context.Itemacervos.Find(idItemAcervo);
			_context.Remove(_itemAcervo);
			_context.SaveChanges();
		}

		public void Edit(Itemacervo itemAcervo)
		{
			throw new NotImplementedException();
		}

		public Itemacervo Get(int idItemAcervo)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Itemacervo> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
