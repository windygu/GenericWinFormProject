using System;
using System.Runtime.Serialization;

namespace App.WinForm
{
    [Serializable]

    // Déclenché sur une propriété qui doit être existe, mais il n'existe pas ou nommé par une autre nom
    public class PropertyDoesNotExistException : Exception
    {
        public PropertyDoesNotExistException()
        {
        }

        public PropertyDoesNotExistException(string message) : base(message)
        {
        }

        public PropertyDoesNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PropertyDoesNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}