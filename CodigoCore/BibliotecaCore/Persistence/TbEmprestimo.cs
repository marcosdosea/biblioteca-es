using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbEmprestimo
    {
        public TbEmprestimo()
        {
            TbEmprestimoitemacervo = new HashSet<TbEmprestimoitemacervo>();
        }

        public int IdEmprestimo { get; set; }
        public string CpfBalconista { get; set; }
        public string CpfUsuario { get; set; }
        public DateTime? Data { get; set; }

        public virtual TbUsuario CpfBalconistaNavigation { get; set; }
        public virtual TbUsuario CpfUsuarioNavigation { get; set; }
        public virtual ICollection<TbEmprestimoitemacervo> TbEmprestimoitemacervo { get; set; }
    }
}
