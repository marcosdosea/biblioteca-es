using System.Collections.Generic;

namespace Core
{
	public interface IAutorService
	{
		void Editar(Autor autorModel);
		int Inserir(Autor autorModel);
		Autor Obter(int idAutor);
		IEnumerable<Autor> ObterPorNome(string nome);
		IEnumerable<Autor> ObterTodos();
		void Remover(int idAutor);

		IEnumerable<AutorDTO> ObterPorNomeOrdenadoDescending(string nome);
	}
}