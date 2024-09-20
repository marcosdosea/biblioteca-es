namespace Core;

public partial class Doacao
{
    public uint Id { get; set; }

    public DateTime Data { get; set; }

    public virtual ICollection<Itemacervo> Itemacervos { get; set; } = new List<Itemacervo>();
}
