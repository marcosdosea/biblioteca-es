namespace Core;

public partial class Editora
{
    public uint Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Rua { get; set; }

    public string? Bairro { get; set; }

    public string? Numero { get; set; }

    public string? Cep { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
}
