using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class AutorViewModel
    {
        //[Display(Name ="Código")]
        [Required(ErrorMessage = "Código do autor é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "Nome do autor deve ter entre 5 e 45 caracteres")]
        public string? Nome { get; set; }

        [Display(Name = "Data Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        public DateTime DataNascimento { get; set; }
    }
}
