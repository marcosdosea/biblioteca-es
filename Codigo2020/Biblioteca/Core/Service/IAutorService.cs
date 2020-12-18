using System.Collections.Generic;

namespace Core
{
	public interface IAutorService
	{
		void Editar(Autor autor);
		int Inserir(Autor autor);
		Autor Obter(int idAutor);
		IEnumerable<Autor> ObterPorNome(string nome);
		IEnumerable<Autor> ObterTodos();
		void Remover(int idAutor);
		IEnumerable<AutorDTO> ObterPorNomeOrdenadoDescending(string nome);
	}
}