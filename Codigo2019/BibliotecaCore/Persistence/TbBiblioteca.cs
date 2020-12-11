using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbBiblioteca
    {
        public TbBiblioteca()
        {
            TbItemacervo = new HashSet<TbItemacervo>();
        }

        public int IdBiblioteca { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<TbItemacervo> TbItemacervo { get; set; }
    }
}
