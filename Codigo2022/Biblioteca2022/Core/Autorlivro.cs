using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Autorlivro
    {
        public int IdAutor { get; set; }
        public int IdLivro { get; set; }

        public virtual Autor IdAutorNavigation { get; set; }
        public virtual Livro IdLivroNavigation { get; set; }
    }
}
