using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IEditoraService
	{
		int Create(Editora editora);
		void Edit(Editora editora);
		void Delete(int idEditora);
		Editora Get(int idEditora);
		IEnumerable<Editora> GetAll();
		IEnumerable<Editora> GetByNome(string nome);
	}
}
