using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AutorModel
    {
		[Display(Name ="Código")]
		[Required(ErrorMessage = "Código do autor é obrigatório")]
		public int IdAutor { get; set; }

		[Required(ErrorMessage ="Campo requerido")]
		[StringLength(45, MinimumLength =5, ErrorMessage = "Nome do autor deve ter entre 5 e 45 caracteres")]
		public string Nome { get; set; }
		
		[Display(Name = "Data Nascimento")]
		[DataType(DataType.Date, ErrorMessage ="Data válida requerida")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime AnoNascimento { get; set; }
    }
}
