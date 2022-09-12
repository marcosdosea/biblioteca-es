using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Biblioteca
    {
        public Biblioteca()
        {
            Itemacervos = new HashSet<Itemacervo>();
        }

        public int IdBiblioteca { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Itemacervo> Itemacervos { get; set; }
    }
}
