using System;
using System.Runtime.Serialization;

namespace App.WinForm.Attributes
{
    [Serializable]
    internal class DisplayMember_NotExist_In_DisplayEntityAttribute_Exception : Exception
    {
        public DisplayMember_NotExist_In_DisplayEntityAttribute_Exception()
        {
        }

        public DisplayMember_NotExist_In_DisplayEntityAttribute_Exception(string message) : base(message)
        {
        }

        public DisplayMember_NotExist_In_DisplayEntityAttribute_Exception(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DisplayMember_NotExist_In_DisplayEntityAttribute_Exception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}