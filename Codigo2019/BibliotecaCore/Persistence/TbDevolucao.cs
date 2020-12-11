using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbDevolucao
    {
        public TbDevolucao()
        {
            TbDevolucaoitemacervo = new HashSet<TbDevolucaoitemacervo>();
        }

        public int IdDevolucao { get; set; }
        public string CpfBalconista { get; set; }
        public string CpfUsuario { get; set; }
        public DateTime? Data { get; set; }
        public decimal? Multa { get; set; }
        public decimal? ValorPago { get; set; }

        public virtual TbUsuario CpfBalconistaNavigation { get; set; }
        public virtual TbUsuario CpfUsuarioNavigation { get; set; }
        public virtual ICollection<TbDevolucaoitemacervo> TbDevolucaoitemacervo { get; set; }
    }
}
