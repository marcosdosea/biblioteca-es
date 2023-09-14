using System;
using System.Collections.Generic;

namespace Core;

public partial class Pessoa
{
    public uint Id { get; set; }

    public string Cpf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string? Cep { get; set; }

    public string? Rua { get; set; }

    public string? Numero { get; set; }

    public string? Bairro { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public string? Fone { get; set; }

    public string? Fone2 { get; set; }

    public string TipoPessoa { get; set; } = null!;

    public virtual ICollection<Devolucao> DevolucaoIdPessoaBalconistaNavigations { get; set; } = new List<Devolucao>();

    public virtual ICollection<Devolucao> DevolucaoIdPessoaUsuarioNavigations { get; set; } = new List<Devolucao>();

    public virtual ICollection<Emprestimo> EmprestimoIdPessoaBalconistaNavigations { get; set; } = new List<Emprestimo>();

    public virtual ICollection<Emprestimo> EmprestimoIdPessoaUsuarioNavigations { get; set; } = new List<Emprestimo>();
}
