using System;
using System.Collections.Generic;

namespace Model
{
    public class Editora
    {
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
