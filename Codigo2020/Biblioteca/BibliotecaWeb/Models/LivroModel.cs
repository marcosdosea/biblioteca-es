using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
	public partial class LivroModel
    {
		[Key]
		public int IdLivro { get; set; }
		[Required]
		[StringLength(20)]
        public string Isbn { get; set; }
		[Display(Name ="Editora")]
        public int IdEditora { get; set; }
		[StringLength(50)]
		public string Nome { get; set; }
		[DataType(DataType.Date)]
		[Display(Name ="Data Publicação")]
        public DateTime? DataPublicacao { get; set; }
		[StringLength(300)]
		public string Resumo { get; set; }
		[Display(Name = "Nome Editora")]
		public string NomeEditora { get; set; }
    }
}
