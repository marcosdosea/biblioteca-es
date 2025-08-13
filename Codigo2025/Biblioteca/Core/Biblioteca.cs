namespace Core;

public partial class Biblioteca
{
    public uint Id { get; set; }

    public string? Nome { get; set; }

    public virtual ICollection<Itemacervo> Itemacervos { get; set; } = new List<Itemacervo>();
}
