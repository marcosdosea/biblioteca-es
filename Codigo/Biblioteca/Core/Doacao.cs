using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Doacao
    {
        public Doacao()
        {
            Itemacervo = new HashSet<Itemacervo>();
        }

        public int IdDoacao { get; set; }
        public DateTime? Data { get; set; }

        public virtual ICollection<Itemacervo> Itemacervo { get; set; }
    }
}
