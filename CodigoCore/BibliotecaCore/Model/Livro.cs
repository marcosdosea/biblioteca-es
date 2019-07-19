using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Livro
    {
        public string Isbn { get; set; }
        public int IdEditora { get; set; }
        public string Nome { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string Resumo { get; set; }

    }
}
