using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Situacaolivro
    {
        public Situacaolivro()
        {
            Itemacervo = new HashSet<Itemacervo>();
        }

        public string IdSituacaoLivro { get; set; }
        public string Situacao { get; set; }

        public virtual ICollection<Itemacervo> Itemacervo { get; set; }
    }
}
