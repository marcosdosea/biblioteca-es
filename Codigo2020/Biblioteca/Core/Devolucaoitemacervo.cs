using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Devolucaoitemacervo
    {
        public int IdDevolucao { get; set; }
        public int IdItemAcervo { get; set; }

        public virtual Devolucao IdDevolucaoNavigation { get; set; }
        public virtual Itemacervo IdItemAcervoNavigation { get; set; }
    }
}
