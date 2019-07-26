using System.Collections.Generic;
using Model;

namespace Service
{
	public interface IGerenciadorLivro
	{
		void Editar(Livro livroModel);
		void Inserir(Livro livroModel);
		Livro Obter(int idLivro);
		IEnumerable<Livro> ObterPorNome(string nome);
		IEnumerable<Livro> ObterTodos();
		void Remover(int idLivro);
	}
}