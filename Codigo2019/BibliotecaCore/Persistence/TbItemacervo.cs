using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbItemacervo
    {
        public TbItemacervo()
        {
            TbDevolucaoitemacervo = new HashSet<TbDevolucaoitemacervo>();
            TbEmprestimoitemacervo = new HashSet<TbEmprestimoitemacervo>();
        }

        public int IdItemAcervo { get; set; }
        public int IdBiblioteca { get; set; }
        public string IdSituacaoLivro { get; set; }
        public string Isbn { get; set; }
        public int? IdDoacao { get; set; }

        public virtual TbBiblioteca IdBibliotecaNavigation { get; set; }
        public virtual TbDoacao IdDoacaoNavigation { get; set; }
        public virtual TbSituacaolivro IdSituacaoLivroNavigation { get; set; }
        public virtual TbLivro IsbnNavigation { get; set; }
        public virtual ICollection<TbDevolucaoitemacervo> TbDevolucaoitemacervo { get; set; }
        public virtual ICollection<TbEmprestimoitemacervo> TbEmprestimoitemacervo { get; set; }
    }
}
