namespace Core;

public partial class Autor
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateTime DataNascimento { get; set; }

    public virtual ICollection<Livro> IdLivros { get; set; } = new List<Livro>();
}
