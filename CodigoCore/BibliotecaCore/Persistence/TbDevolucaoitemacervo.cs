using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbDevolucaoitemacervo
    {
        public int IdDevolucao { get; set; }
        public int IdItemAcervo { get; set; }

        public virtual TbDevolucao IdDevolucaoNavigation { get; set; }
        public virtual TbItemacervo IdItemAcervoNavigation { get; set; }
    }
}
