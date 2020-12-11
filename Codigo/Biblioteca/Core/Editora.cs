using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Editora
    {
        public Editora()
        {
            Livro = new HashSet<Livro>();
        }

        public int IdEditora { get; set; }
        public string Nome { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Livro> Livro { get; set; }
    }
}
