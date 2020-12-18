using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Itemacervo
    {
        public Itemacervo()
        {
            Devolucaoitemacervo = new HashSet<Devolucaoitemacervo>();
            Emprestimoitemacervo = new HashSet<Emprestimoitemacervo>();
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
        public virtual ICollection<Devolucaoitemacervo> Devolucaoitemacervo { get; set; }
        public virtual ICollection<Emprestimoitemacervo> Emprestimoitemacervo { get; set; }
    }
}
