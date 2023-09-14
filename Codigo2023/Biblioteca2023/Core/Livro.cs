using System;
using System.Collections.Generic;

namespace Core;

public partial class Livro
{
    public uint Id { get; set; }

    public string Isbn { get; set; } = null!;

    public uint IdEditora { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime? DataPublicacao { get; set; }

    public string? Resumo { get; set; }

    public byte[]? FotoCapa { get; set; }

    public virtual Editora IdEditoraNavigation { get; set; } = null!;

    public virtual ICollection<Itemacervo> Itemacervos { get; set; } = new List<Itemacervo>();

    public virtual ICollection<Autor> IdAutors { get; set; } = new List<Autor>();
}
