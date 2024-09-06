using System;
using System.Collections.Generic;

namespace Core;

public partial class Situacaoitemacervo
{
    public string Id { get; set; } = null!;

    public string Situacao { get; set; } = null!;

    public virtual ICollection<Itemacervo> Itemacervos { get; set; } = new List<Itemacervo>();
}
