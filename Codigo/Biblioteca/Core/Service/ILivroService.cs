using System.Collections.Generic;

namespace Core
{
	public interface ILivroService
	{
		void Editar(Livro livro);
		void Inserir(Livro livro);
		Livro Obter(int idLivro);
		IEnumerable<Livro> ObterPorNome(string nome);
		IEnumerable<Livro> ObterTodos();
		void Remover(int idLivro);
	}
}