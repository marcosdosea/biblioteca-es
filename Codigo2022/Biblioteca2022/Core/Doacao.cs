using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Doacao
    {
        public Doacao()
        {
            Itemacervos = new HashSet<Itemacervo>();
        }

        public int IdDoacao { get; set; }
        public DateTime? Data { get; set; }

        public virtual ICollection<Itemacervo> Itemacervos { get; set; }
    }
}
