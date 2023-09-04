using System;
using System.Collections.Generic;

namespace Core;

public partial class Itemacervo
{
    public int IdItemAcervo { get; set; }

    public uint IdLivro { get; set; }

    public int IdBiblioteca { get; set; }

    public string IdSituacaoLivro { get; set; } = null!;

    public int? IdDoacao { get; set; }

    public virtual Biblioteca IdBibliotecaNavigation { get; set; } = null!;

    public virtual Doacao? IdDoacaoNavigation { get; set; }

    public virtual Livro IdLivroNavigation { get; set; } = null!;

    public virtual Situacaolivro IdSituacaoLivroNavigation { get; set; } = null!;

    public virtual ICollection<Devolucao> IdDevolucaos { get; set; } = new List<Devolucao>();

    public virtual ICollection<Emprestimo> IdEmprestimos { get; set; } = new List<Emprestimo>();
}
