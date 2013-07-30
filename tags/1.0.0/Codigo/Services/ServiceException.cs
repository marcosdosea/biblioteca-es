using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class ServiceException : SystemException
    {

        public ServiceException(String mensagem, Exception inner)
            : base(mensagem, inner)
        {

        }
    }
}
