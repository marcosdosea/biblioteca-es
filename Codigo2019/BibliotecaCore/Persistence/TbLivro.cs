using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbLivro
    {
        public TbLivro()
        {
            TbItemacervo = new HashSet<TbItemacervo>();
            TbLivroautor = new HashSet<TbLivroautor>();
        }

        public string Isbn { get; set; }
        public int IdEditora { get; set; }
        public string Nome { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string Resumo { get; set; }

        public virtual TbEditora IdEditoraNavigation { get; set; }
        public virtual ICollection<TbItemacervo> TbItemacervo { get; set; }
        public virtual ICollection<TbLivroautor> TbLivroautor { get; set; }
    }
}
