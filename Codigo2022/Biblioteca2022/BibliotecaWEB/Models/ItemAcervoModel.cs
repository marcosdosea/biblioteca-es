using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace BibliotecaWEB.Models
{
	public class ItemAcervoModel
	{
		[Required]
		public int IdItemAcervo { get; set; }
		[Required]
		public int IdLivro { get; set; }
		[Required]
		public int IdBiblioteca { get; set; }
		[Required] 
		public string IdSituacaoLivro { get; set; }


		[Phone]
		public string Email { get; set; }


		public int? IdDoacao { get; set; }
	}
}
