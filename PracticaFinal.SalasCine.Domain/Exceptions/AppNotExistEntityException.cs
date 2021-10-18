using System;

namespace PracticaFinal.SalasCine.Domain.Exceptions
{
    public class AppNotExistEntityException : Exception
    {
        public AppNotExistEntityException() { }
        public AppNotExistEntityException(string message) : base(message) { }
        public AppNotExistEntityException(string message, Exception inner) : base(message, inner) { }
        protected AppNotExistEntityException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
