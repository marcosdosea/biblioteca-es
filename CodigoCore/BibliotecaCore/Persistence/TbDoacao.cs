using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbDoacao
    {
        public TbDoacao()
        {
            TbItemacervo = new HashSet<TbItemacervo>();
        }

        public int IdDoacao { get; set; }
        public DateTime? Data { get; set; }

        public virtual ICollection<TbItemacervo> TbItemacervo { get; set; }
    }
}
