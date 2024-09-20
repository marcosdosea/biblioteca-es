using Core.DTO;

namespace Core.Service
{
    public interface ILivroService
    {
        uint Create(Livro livro);
        void Edit(Livro livro);
        void Delete(uint id);
        Livro? Get(uint id);
        IEnumerable<LivroDto> GetAll();
        IEnumerable<LivroDto> GetByNome(string nome);
    }
}
