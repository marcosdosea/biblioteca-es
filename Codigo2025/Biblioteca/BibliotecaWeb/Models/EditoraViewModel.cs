using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class EditoraViewModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da editora deve ser preenchido obrigatoriamente")]
        [StringLength(45, MinimumLength = 5, ErrorMessage = "O campo nome editora deve ter entre 4 e 45 caracteres")]
        public string? Nome { get; set; }
        [StringLength(30)]
        public string? Rua { get; set; }
        [StringLength(30)]
        public string? Bairro { get; set; }
        [Display(Name = "Número")]
        [StringLength(10)]
        public string? Numero { get; set; }
        [StringLength(8)]
        public string? Cep { get; set; }
        [StringLength(30)]
        public string? Cidade { get; set; }
        [StringLength(2)]
        public string? Estado { get; set; }
    }
}
