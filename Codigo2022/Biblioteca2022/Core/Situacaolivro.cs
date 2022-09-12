using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Situacaolivro
    {
        public Situacaolivro()
        {
            Itemacervos = new HashSet<Itemacervo>();
        }

        public string IdSituacaoLivro { get; set; }
        public string Situacao { get; set; }

        public virtual ICollection<Itemacervo> Itemacervos { get; set; }
    }
}
