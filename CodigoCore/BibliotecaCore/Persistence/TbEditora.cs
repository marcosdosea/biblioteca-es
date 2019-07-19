using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbEditora
    {
        public TbEditora()
        {
            TbLivro = new HashSet<TbLivro>();
        }

        public int IdEditora { get; set; }
        public string Nome { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<TbLivro> TbLivro { get; set; }
    }
}
