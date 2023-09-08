using Core.DTO;

namespace Core.Service
{
    public interface IAutorService
    {
        int Create(Autor autor);
        void Edit(Autor autor);
        void Delete(int id);
        Autor? Get(int id);
        IEnumerable<Autor> GetAll();
        IEnumerable<AutorDto> GetByNome(string nome);
    }
}
