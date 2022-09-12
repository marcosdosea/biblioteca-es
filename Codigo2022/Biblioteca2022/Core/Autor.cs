using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Autor
    {
        public Autor()
        {
            Autorlivros = new HashSet<Autorlivro>();
        }

        public int IdAutor { get; set; }
        public string Nome { get; set; }
        public DateTime AnoNascimento { get; set; }

        public virtual ICollection<Autorlivro> Autorlivros { get; set; }
    }
}
