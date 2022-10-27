using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class ItemAcervoDTO
    {
		[DisplayName("Id")]
		public int IdItemAcervo { get; set; }
		[DisplayName("Biblioteca")]
		public string? NomeBiblioteca { get; set; }
		[DisplayName("Livro")]
		public string? NomeLivro { get; set; }
		[DisplayName("Situação")]
		public string? SituacaoLivro { get; set; }
	}
}
