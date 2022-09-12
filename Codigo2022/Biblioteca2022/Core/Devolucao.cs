using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Devolucao
    {
        public Devolucao()
        {
            Devolucaoitemacervos = new HashSet<Devolucaoitemacervo>();
        }

        public int IdDevolucao { get; set; }
        public int IdPessoaUsuario { get; set; }
        public int IdPessoaBalconista { get; set; }
        public DateTime? Data { get; set; }
        public decimal? Multa { get; set; }
        public decimal? ValorPago { get; set; }

        public virtual Pessoa IdPessoaBalconistaNavigation { get; set; }
        public virtual Pessoa IdPessoaUsuarioNavigation { get; set; }
        public virtual ICollection<Devolucaoitemacervo> Devolucaoitemacervos { get; set; }
    }
}
