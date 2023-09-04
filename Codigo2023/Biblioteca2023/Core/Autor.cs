using System;
using System.Collections.Generic;

namespace Core;

public partial class Autor
{
    public int IdAutor { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime AnoNascimento { get; set; }

    public virtual ICollection<Livro> IdLivros { get; set; } = new List<Livro>();
}
