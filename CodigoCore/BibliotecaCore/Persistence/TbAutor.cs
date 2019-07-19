using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbAutor
    {
        public TbAutor()
        {
            TbLivroautor = new HashSet<TbLivroautor>();
        }

        public int IdAutor { get; set; }
        public string Nome { get; set; }
        public DateTime AnoNascimento { get; set; }

        public virtual ICollection<TbLivroautor> TbLivroautor { get; set; }
    }
}
