using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Livro
    {
        public Livro()
        {
            Autorlivro = new HashSet<Autorlivro>();
            Itemacervo = new HashSet<Itemacervo>();
        }

        public int IdLivro { get; set; }
        public string Isbn { get; set; }
        public int IdEditora { get; set; }
        public string Nome { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string Resumo { get; set; }

        public virtual Editora IdEditoraNavigation { get; set; }
        public virtual ICollection<Autorlivro> Autorlivro { get; set; }
        public virtual ICollection<Itemacervo> Itemacervo { get; set; }
    }
}
