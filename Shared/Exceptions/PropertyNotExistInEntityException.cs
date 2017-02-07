using System;
using System.Runtime.Serialization;

namespace App.WinForm.Fields
{
    [Serializable]
    public class PropertyNotExistInEntityException : Exception
    {
        public PropertyNotExistInEntityException()
        {
        }

        public PropertyNotExistInEntityException(string message) : base(message)
        {
        }

        public PropertyNotExistInEntityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PropertyNotExistInEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}