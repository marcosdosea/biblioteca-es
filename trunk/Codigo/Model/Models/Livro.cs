using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Livro
    {
        [Required]
        [StringLength(20)]
        public string Isbn { get; set; }
        
        [Required]
        [Display(Name = "Código Editora")]
        public int IdEditora { get; set; }

        [Display(Name = "Editora")]
        public string NomeEditora { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Livro")]
        public string Nome { get; set; }
        
        [Display(Name = "Data Publicação")]
        [DataType(DataType.Date)]
        public DateTime? DataPublicacao { get; set; }

        public string Resumo { get; set; }

        public IEnumerable<Autor> ListaAutores { get; set; }
    }
}
