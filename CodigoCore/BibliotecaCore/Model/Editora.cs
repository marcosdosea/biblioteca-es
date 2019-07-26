using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Editora
    {
		[Required]
		[Key]
		public int IdEditora { get; set; }
		[Required]
		[StringLength(45, MinimumLength =5)]
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
