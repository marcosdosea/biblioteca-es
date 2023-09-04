using Core.DTO;

namespace Core.Service
{
    public interface IAutorService
    {
        int Create(Autor autor);
        void Edit(Autor autor);
        void Delete(int idAutor);
        Autor Get(int idAutor);
        IEnumerable<Autor> GetAll();
        IEnumerable<AutorDto> GetByNome(string nome);
    }
}
