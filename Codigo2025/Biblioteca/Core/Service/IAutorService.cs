using Core.Datatables;
using Core.DTO;

namespace Core.Service
{
    public interface IAutorService
    {
        uint Create(Autor autor);
        void Edit(Autor autor);
        void Delete(uint id);
        Autor? Get(uint id);
        IEnumerable<Autor> GetAll();
        IEnumerable<AutorDto> GetByNome(string nome);
        DatatableResponse<Autor> GetDataPage(DatatableRequest request);
    }
}
