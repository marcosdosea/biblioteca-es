using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Autor
    {
        public Autor()
        {
            Livroautor = new HashSet<Livroautor>();
        }

        public int IdAutor { get; set; }
        public string Nome { get; set; }
        public DateTime AnoNascimento { get; set; }

        public virtual ICollection<Livroautor> Livroautor { get; set; }
    }
}
