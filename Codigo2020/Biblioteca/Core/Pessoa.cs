using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            DevolucaoIdPessoaBalconistaNavigation = new HashSet<Devolucao>();
            DevolucaoIdPessoaUsuarioNavigation = new HashSet<Devolucao>();
            EmprestimoIdPessoaBalconistaNavigation = new HashSet<Emprestimo>();
            EmprestimoIdPessoaUsuarioNavigation = new HashSet<Emprestimo>();
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

        public virtual ICollection<Devolucao> DevolucaoIdPessoaBalconistaNavigation { get; set; }
        public virtual ICollection<Devolucao> DevolucaoIdPessoaUsuarioNavigation { get; set; }
        public virtual ICollection<Emprestimo> EmprestimoIdPessoaBalconistaNavigation { get; set; }
        public virtual ICollection<Emprestimo> EmprestimoIdPessoaUsuarioNavigation { get; set; }
    }
}
