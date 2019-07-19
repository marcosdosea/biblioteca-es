using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Autor
    {
		[Required]
		[Display(Name = "Código")]
		public int IdAutor { get; set; }
		[Required]
		[Display(Name = "Nome")]
		[StringLength(100)]
		public string Nome { get; set; }
		[Display(Name = "Ano Nascimento")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime AnoNascimento { get; set; }
    }
}
