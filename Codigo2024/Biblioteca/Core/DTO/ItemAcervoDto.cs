using System.ComponentModel;

namespace Core.DTO
{
    public class ItemAcervoDto
    {
		[DisplayName("Id")]
		public uint Id { get; set; }
		[DisplayName("Biblioteca")]
		public string? NomeBiblioteca { get; set; }
		[DisplayName("Livro")]
		public string? NomeLivro { get; set; }
		[DisplayName("Situação")]
		public string? SituacaoItemAcervo { get; set; }
	}
}
