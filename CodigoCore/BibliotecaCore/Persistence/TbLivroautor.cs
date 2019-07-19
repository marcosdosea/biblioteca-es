using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbLivroautor
    {
        public string Isbn { get; set; }
        public int IdAutor { get; set; }

        public virtual TbAutor IdAutorNavigation { get; set; }
        public virtual TbLivro IsbnNavigation { get; set; }
    }
}
