using System.ComponentModel;

namespace Core.DTO
{
    public class ItemAcervoDto
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
