using Microsoft.Build.Framework;

namespace BibliotecaWEB.Models
{
	public class BbiliotecaModel
	{
		[Required]
		public int IdBiblioteca { get; set; }
		[Required]
		public string Nome { get; set; }
	}
}
