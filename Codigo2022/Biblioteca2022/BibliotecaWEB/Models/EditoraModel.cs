using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class EditoraModel
    {
		[Required]
		[Key]
		public int IdEditora { get; set; }
		[Required(ErrorMessage ="O nome da editora deve ser preenchido obrigatoriamente")]
		[StringLength(45, MinimumLength =5, ErrorMessage ="O campo nome editora deve ter entre 4 e 45 caracteres")]
		public string Nome { get; set; }
		[StringLength(30)]
		public string Rua { get; set; }
		[StringLength(30)]
		public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
