namespace Core.Service
{
	public interface IItemAcervoService
	{
		int Create(Itemacervo itemAcervo);
		void Edit(Itemacervo itemAcervo);
		void Delete(int idItemAcervo);
		Itemacervo Get(int idItemAcervo);
		IEnumerable<Itemacervo> GetAll();
	}
}
