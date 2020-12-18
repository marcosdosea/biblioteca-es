using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Autor
    {
        public Autor()
        {
            Autorlivro = new HashSet<Autorlivro>();
        }

        public int IdAutor { get; set; }
        public string Nome { get; set; }
        public DateTime AnoNascimento { get; set; }

        public virtual ICollection<Autorlivro> Autorlivro { get; set; }
    }
}
