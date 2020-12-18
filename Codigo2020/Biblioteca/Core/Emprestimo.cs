using System;
using System.Collections.Generic;

namespace Core
{
    public partial class Emprestimo
    {
        public Emprestimo()
        {
            Emprestimoitemacervo = new HashSet<Emprestimoitemacervo>();
        }

        public int IdEmprestimo { get; set; }
        public int IdPessoaUsuario { get; set; }
        public int IdPessoaBalconista { get; set; }
        public DateTime Data { get; set; }

        public virtual Pessoa IdPessoaBalconistaNavigation { get; set; }
        public virtual Pessoa IdPessoaUsuarioNavigation { get; set; }
        public virtual ICollection<Emprestimoitemacervo> Emprestimoitemacervo { get; set; }
    }
}
