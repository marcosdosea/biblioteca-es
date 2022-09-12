using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            DevolucaoIdPessoaBalconistaNavigations = new HashSet<Devolucao>();
            DevolucaoIdPessoaUsuarioNavigations = new HashSet<Devolucao>();
            EmprestimoIdPessoaBalconistaNavigations = new HashSet<Emprestimo>();
            EmprestimoIdPessoaUsuarioNavigations = new HashSet<Emprestimo>();
        }

        public int IdPessoa { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Fone { get; set; }
        public string Fone2 { get; set; }
        public string TipoPessoa { get; set; }

        public virtual ICollection<Devolucao> DevolucaoIdPessoaBalconistaNavigations { get; set; }
        public virtual ICollection<Devolucao> DevolucaoIdPessoaUsuarioNavigations { get; set; }
        public virtual ICollection<Emprestimo> EmprestimoIdPessoaBalconistaNavigations { get; set; }
        public virtual ICollection<Emprestimo> EmprestimoIdPessoaUsuarioNavigations { get; set; }
    }
}
