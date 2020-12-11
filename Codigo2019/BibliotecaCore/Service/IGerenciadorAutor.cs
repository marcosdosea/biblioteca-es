using Data;
using Model;
using System.Collections.Generic;

namespace Service
{
	public interface IGerenciadorAutor
	{
		void Editar(Autor autorModel);
		int Inserir(Autor autorModel);
		Autor Obter(int idAutor);
		IEnumerable<Autor> ObterPorNome(string nome);
		IEnumerable<Autor> ObterTodos();
		void Remover(int idAutor);
	}
}