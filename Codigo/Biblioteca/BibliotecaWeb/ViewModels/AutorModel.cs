using ViewModel.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModel
{
    public class AutorModel
    {
		[Display(Name ="IdAutor", ResourceType=typeof(Mensagem))]
		[Required(ErrorMessageResourceType = typeof(Mensagem), 
			ErrorMessageResourceName = "campo_requerido")]
		public int IdAutor { get; set; }
		[Required]
		[Display(Name = "Nome")]
		[StringLength(45, MinimumLength =5)]
		public string Nome { get; set; }
		[Display(Name = "Ano Nascimento")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
		public DateTime AnoNascimento { get; set; }
    }
}
