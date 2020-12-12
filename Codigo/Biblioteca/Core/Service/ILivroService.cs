using System.Collections.Generic;

namespace Core
{
	public interface ILivroService
	{
		void Editar(Livro livro);
		void Inserir(Livro livro);
		Livro Obter(string isbn);
		IEnumerable<LivroDTO> ObterPorNome(string nome);
		IEnumerable<Livro> ObterTodos();
		void Remover(int idLivro);
	}
}