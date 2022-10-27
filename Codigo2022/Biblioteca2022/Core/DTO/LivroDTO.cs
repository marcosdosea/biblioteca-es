using System.ComponentModel;

namespace Core.DTO
{
	public class LivroDTO
	{
		public int IdLivro { get; set; }
		public string? Isbn { get; set; }
		public string? Nome { get; set; }
		[DisplayName("Editora")]
		public string? NomeEditora { get; set; }

	}
}
