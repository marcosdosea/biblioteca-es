using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Biblioteca
    {
        public Biblioteca()
        {
            Itemacervo = new HashSet<Itemacervo>();
        }

        public int IdBiblioteca { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Itemacervo> Itemacervo { get; set; }
    }
}
