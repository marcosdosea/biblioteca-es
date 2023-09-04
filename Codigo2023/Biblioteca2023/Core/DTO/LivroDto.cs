using System.ComponentModel;

namespace Core.DTO
{
	public class LivroDto
	{
		public uint IdLivro { get; set; }
		public string? Isbn { get; set; }
		public string? Nome { get; set; }
		[DisplayName("Editora")]
		public string? NomeEditora { get; set; }

	}
}
