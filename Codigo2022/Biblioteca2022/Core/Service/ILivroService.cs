using BibliotecaWEB.Models;
using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public interface ILivroService
	{
		int Create(Livro livro);
		void Edit(Livro livro);
		void Delete(int idLivro);
		Livro Get(int idLivro);
		IEnumerable<LivroDTO> GetAll();
		IEnumerable<LivroDTO> GetByNome(string nome);
		public IEnumerable<LivroDTO> GetByPage(DatatableDTO model, out int filteredResultsCount, out int totalResultsCount);
	}
}
