using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaWEB.Models
{
    public class ItemAcervoViewModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdLivro { get; set; }
        [Required]
        public int IdBiblioteca { get; set; }
        [Required]
        public string? IdSituacaoLivro { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        public int? IdDoacao { get; set; }
        public SelectList? ListaLivros { get; set; }
    }
}
