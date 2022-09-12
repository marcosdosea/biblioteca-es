using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
	public class ServiceException : Exception
	{
		public ServiceException(string? message) : base(message)
		{
		}

		public ServiceException(String mensagem, Exception inner)
			: base(mensagem, inner)
		{

		}
	}
}
