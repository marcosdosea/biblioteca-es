using System.Collections.Generic;

namespace Core
{
	public interface IItemAcervoService
	{
		int Inserir(Itemacervo itemAcervo);
		void Editar(Itemacervo itemAcervo);
		Itemacervo Obter(int idItemAcervo);
		IEnumerable<Itemacervo> ObterTodos();
		void Remover(int idItemAcervo);
	}
}