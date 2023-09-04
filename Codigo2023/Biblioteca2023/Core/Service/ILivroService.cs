using Core.DTO;

namespace Core.Service
{
    public interface ILivroService
	{
		uint Create(Livro livro);
		void Edit(Livro livro);
		void Delete(int idLivro);
		Livro Get(int idLivro);
		IEnumerable<LivroDto> GetAll();
		IEnumerable<LivroDto> GetByNome(string nome);
	}
}
