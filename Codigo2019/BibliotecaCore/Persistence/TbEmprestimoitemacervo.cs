using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbEmprestimoitemacervo
    {
        public int IdItemAcervo { get; set; }
        public int IdEmprestimo { get; set; }

        public virtual TbEmprestimo IdEmprestimoNavigation { get; set; }
        public virtual TbItemacervo IdItemAcervoNavigation { get; set; }
    }
}
