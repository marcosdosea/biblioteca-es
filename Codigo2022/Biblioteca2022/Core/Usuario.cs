using System;
using System.Collections.Generic;

#nullable disable

namespace Core
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string TipoUsuario { get; set; }
    }
}
