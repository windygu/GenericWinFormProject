using System;
using System.Runtime.Serialization;

namespace App.WinForm
{
    [Serializable]
    internal class FieldNotExistInFormException : Exception
    {
        /// <summary>
        /// cet exception est lancé sur un champs qui doive être dans l'interface mais il n'existe pas
        /// </summary>
        public FieldNotExistInFormException()
        {
        }

        public FieldNotExistInFormException(string message) : base(message)
        {
        }

        public FieldNotExistInFormException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FieldNotExistInFormException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}