using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Livro
    {
        public Livro()
        {
            Autorlivros = new HashSet<Autorlivro>();
            Itemacervos = new HashSet<Itemacervo>();
        }

        public int IdLivro { get; set; }
        public string Isbn { get; set; }
        public int IdEditora { get; set; }
        public string Nome { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string Resumo { get; set; }

        public virtual Editora IdEditoraNavigation { get; set; }
        public virtual ICollection<Autorlivro> Autorlivros { get; set; }
        public virtual ICollection<Itemacervo> Itemacervos { get; set; }
    }
}
