using System;
using System.Collections.Generic;

namespace Data
{
    public partial class TbUsuario
    {
        public TbUsuario()
        {
            TbDevolucaoCpfBalconistaNavigation = new HashSet<TbDevolucao>();
            TbDevolucaoCpfUsuarioNavigation = new HashSet<TbDevolucao>();
            TbEmprestimoCpfBalconistaNavigation = new HashSet<TbEmprestimo>();
            TbEmprestimoCpfUsuarioNavigation = new HashSet<TbEmprestimo>();
        }

        public string Cpf { get; set; }
        public int IdCartaoBiblioteca { get; set; }
        public string TipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime? DataNascimento { get; set; }
        public decimal? Debito { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public virtual TbCartaobiblioteca IdCartaoBibliotecaNavigation { get; set; }
        public virtual ICollection<TbDevolucao> TbDevolucaoCpfBalconistaNavigation { get; set; }
        public virtual ICollection<TbDevolucao> TbDevolucaoCpfUsuarioNavigation { get; set; }
        public virtual ICollection<TbEmprestimo> TbEmprestimoCpfBalconistaNavigation { get; set; }
        public virtual ICollection<TbEmprestimo> TbEmprestimoCpfUsuarioNavigation { get; set; }
    }
}
