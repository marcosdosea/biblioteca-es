using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Editora
    {
        [Required]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(40)]
        public string Nome { get; set; }

        [Display(Name = "Rua")]
        public string Rua { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }
        
        [Display(Name = "Estado")]
        [StringLength(2 , MinimumLength=2)]
        public string Estado { get; set; }
        
        [Display(Name = "Cep")]
        [StringLength(8, MinimumLength = 8)]
        public string Cep { get; set; }

    }
}
