using System;
using System.Collections.Generic;

namespace Core;

public partial class Situacaolivro
{
    public string IdSituacaoLivro { get; set; } = null!;

    public string? Situacao { get; set; }

    public virtual ICollection<Itemacervo> Itemacervos { get; set; } = new List<Itemacervo>();
}
