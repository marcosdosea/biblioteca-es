using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence
{
    public class PersistenceException : SystemException
    {

        public PersistenceException(String mensagem, Exception inner)
            : base(mensagem, inner)
        {

        }
    }
}
