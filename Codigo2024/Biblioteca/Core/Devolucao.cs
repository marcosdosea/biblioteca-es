namespace Core;

public partial class Devolucao
{
    public uint Id { get; set; }

    public uint IdPessoaUsuario { get; set; }

    public uint IdPessoaBalconista { get; set; }

    public DateTime Data { get; set; }

    public decimal? Multa { get; set; }

    public decimal? ValorPago { get; set; }

    public virtual Pessoa IdPessoaBalconistaNavigation { get; set; } = null!;

    public virtual Pessoa IdPessoaUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Itemacervo> IdItemAcervos { get; set; } = new List<Itemacervo>();
}
