using System.Runtime.Serialization;

namespace Core.Service
{
    [Serializable]
    public class ServiceException : Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(string? message) : base(message)
        {
        }

        public ServiceException(string mensagem, Exception inner)
            : base(mensagem, inner)
        {

        }

        protected ServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
