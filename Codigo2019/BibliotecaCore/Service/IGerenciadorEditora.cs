using System.Collections.Generic;
using Model;

namespace Service
{
	public interface IGerenciadorEditora
	{
		void Editar(Editora editoraModel);
		int Inserir(Editora editoraModel);
		Editora Obter(int idEditora);
		IEnumerable<Editora> ObterPorNome(string nome);
		IEnumerable<Editora> ObterTodos();
		void Remover(int idEditora);
	}
}