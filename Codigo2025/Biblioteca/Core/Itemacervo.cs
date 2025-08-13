namespace Core;

public partial class Itemacervo
{
    public uint Id { get; set; }

    public uint IdLivro { get; set; }

    public string IdSituacaoItemAcervo { get; set; } = null!;

    public uint? IdDoacao { get; set; }

    public DateTime DataAquisicao { get; set; }

    public uint IdBiblioteca { get; set; }

    public virtual Biblioteca IdBibliotecaNavigation { get; set; } = null!;

    public virtual Doacao? IdDoacaoNavigation { get; set; }

    public virtual Livro IdLivroNavigation { get; set; } = null!;

    public virtual Situacaoitemacervo IdSituacaoItemAcervoNavigation { get; set; } = null!;

    public virtual ICollection<Devolucao> IdDevolucaos { get; set; } = new List<Devolucao>();

    public virtual ICollection<Emprestimo> IdEmprestimos { get; set; } = new List<Emprestimo>();
}
