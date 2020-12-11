using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Emprestimoitemacervo
    {
        public int IdItemAcervo { get; set; }
        public int IdEmprestimo { get; set; }

        public virtual Emprestimo IdEmprestimoNavigation { get; set; }
        public virtual Itemacervo IdItemAcervoNavigation { get; set; }
    }
}
