using System.ComponentModel.DataAnnotations;
using Util;

namespace BibliotecaWEB.Models
{
    public class PessoaViewModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [CPF]
        public string? Cpf { get; set; }


        [StringLength(30)]
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        [TelefoneFixo]
        public string? Fone { get; set; }
        [TelefoneCelular]
        public string? Fone2 { get; set; }
        public string? TipoPessoa { get; set; }
    }
}
