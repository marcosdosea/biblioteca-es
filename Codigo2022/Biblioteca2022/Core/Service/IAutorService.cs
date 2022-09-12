using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface IAutorService
	{
		int Create(Autor autor);
		void Edit(Autor autor);
		void Delete(int idAutor);
		Autor Get(int idAutor);
		IEnumerable<Autor> GetAll();
		IEnumerable<AutorDTO> GetByNome(string nome);
	}
}
