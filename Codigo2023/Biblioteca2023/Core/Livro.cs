using System;
using System.Collections.Generic;

namespace Core;

public partial class Livro
{
    public uint IdLivro { get; set; }

    public string Isbn { get; set; } = null!;

    public int IdEditora { get; set; }

    public string? Nome { get; set; }

    public DateTime? DataPublicacao { get; set; }

    public string? Resumo { get; set; }

    public virtual Editora IdEditoraNavigation { get; set; } = null!;

    public virtual ICollection<Itemacervo> Itemacervos { get; set; } = new List<Itemacervo>();

    public virtual ICollection<Autor> IdAutors { get; set; } = new List<Autor>();
}
