using System.Collections.Generic;

namespace Core
{
	public interface IEditoraService
	{
		void Editar(Editora editora);
		int Inserir(Editora editora);
		Editora Obter(int idEditora);
		IEnumerable<Editora> ObterPorNome(string nome);
		IEnumerable<Editora> ObterTodos();
		void Remover(int idEditora);
	}
}