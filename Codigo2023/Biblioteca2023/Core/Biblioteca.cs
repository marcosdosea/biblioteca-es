using System;
using System.Collections.Generic;

namespace Core;

public partial class Biblioteca
{
    public int IdBiblioteca { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Itemacervo> Itemacervos { get; set; } = new List<Itemacervo>();
}
