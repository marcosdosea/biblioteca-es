using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public partial class LivroViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string? Isbn { get; set; }
        [Display(Name = "Editora")]
        public int IdEditora { get; set; }
        [StringLength(50)]
        public string? Nome { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data Publicação")]
        public DateTime? DataPublicacao { get; set; }
        [StringLength(300)]
        public string? Resumo { get; set; }
        [Display(Name = "Foto da Capa")]
        public byte[]? FotoCapa { get; set; }
        [Display(Name = "Editora")]
        public SelectList? ListaEditoras { get; set; }
        public SelectList? ListaAutores { get; set; }
    }
}
