using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Livroautor
    {
        public string Isbn { get; set; }
        public int IdAutor { get; set; }

        public virtual Autor IdAutorNavigation { get; set; }
        public virtual Livro IsbnNavigation { get; set; }
    }
}
