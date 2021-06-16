using System.Collections.Generic;

namespace Core
{
	public interface IAutorService
	{
		void Editar(Autor autor);
		int Inserir(Autor autor);
		Autor Obter(int idAutor);
		IEnumerable<Autor> ObterPorNome(string nome);
		public IEnumerable<Autor> ObterPorNomeContendo(string nome);
		IEnumerable<Autor> ObterTodos();
		IEnumerable<Autor> ObterTodosOrdenadoPorNome();
		void Remover(int idAutor);
		IEnumerable<AutorDTO> ObterPorNomeOrdenadoDescending(string nome);
	}
}