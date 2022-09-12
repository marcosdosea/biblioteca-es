using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Itemacervo
    {
        public Itemacervo()
        {
            Devolucaoitemacervos = new HashSet<Devolucaoitemacervo>();
            Emprestimoitemacervos = new HashSet<Emprestimoitemacervo>();
        }

        public int IdItemAcervo { get; set; }
        public int IdLivro { get; set; }
        public int IdBiblioteca { get; set; }
        public string IdSituacaoLivro { get; set; }
        public int? IdDoacao { get; set; }

        public virtual Biblioteca IdBibliotecaNavigation { get; set; }
        public virtual Doacao IdDoacaoNavigation { get; set; }
        public virtual Livro IdLivroNavigation { get; set; }
        public virtual Situacaolivro IdSituacaoLivroNavigation { get; set; }
        public virtual ICollection<Devolucaoitemacervo> Devolucaoitemacervos { get; set; }
        public virtual ICollection<Emprestimoitemacervo> Emprestimoitemacervos { get; set; }
    }
}
