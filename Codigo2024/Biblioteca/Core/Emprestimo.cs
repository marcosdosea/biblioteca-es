using System;
using System.Collections.Generic;

namespace Core;

public partial class Emprestimo
{
    public uint Id { get; set; }

    public uint IdPessoaUsuario { get; set; }

    public uint IdPessoaBalconista { get; set; }

    public DateTime Data { get; set; }

    public virtual Pessoa IdPessoaBalconistaNavigation { get; set; } = null!;

    public virtual Pessoa IdPessoaUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Itemacervo> IdItemAcervos { get; set; } = new List<Itemacervo>();
}
