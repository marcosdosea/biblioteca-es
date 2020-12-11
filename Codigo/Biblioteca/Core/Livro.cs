using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Livro
    {
        public Livro()
        {
            Itemacervo = new HashSet<Itemacervo>();
            Livroautor = new HashSet<Livroautor>();
        }

        public string Isbn { get; set; }
        public int IdEditora { get; set; }
        public string Nome { get; set; }
        public DateTime? DataPublicacao { get; set; }
        public string Resumo { get; set; }

        public virtual Editora IdEditoraNavigation { get; set; }
        public virtual ICollection<Itemacervo> Itemacervo { get; set; }
        public virtual ICollection<Livroautor> Livroautor { get; set; }
    }
}
