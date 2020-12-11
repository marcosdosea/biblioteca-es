using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbCartaobiblioteca
    {
        public TbCartaobiblioteca()
        {
            TbUsuario = new HashSet<TbUsuario>();
        }

        public int IdCartaoBiblioteca { get; set; }
        public DateTime? Validade { get; set; }

        public virtual ICollection<TbUsuario> TbUsuario { get; set; }
    }
}
