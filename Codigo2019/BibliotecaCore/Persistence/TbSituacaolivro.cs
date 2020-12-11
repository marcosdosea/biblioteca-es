using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbSituacaolivro
    {
        public TbSituacaolivro()
        {
            TbItemacervo = new HashSet<TbItemacervo>();
        }

        public string IdSituacaoLivro { get; set; }
        public string Situacao { get; set; }

        public virtual ICollection<TbItemacervo> TbItemacervo { get; set; }
    }
}
