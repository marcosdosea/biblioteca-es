using Core.DTO;

namespace Core.Service
{
    public interface IItemAcervoService
    {
        uint Create(Itemacervo itemAcervo);
        void Edit(Itemacervo itemAcervo);
        void Delete(int id);
        Itemacervo? Get(int id);
        IEnumerable<ItemAcervoDto> GetAll();
    }
}
