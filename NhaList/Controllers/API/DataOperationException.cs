using System;

namespace NhaList.Controllers.API
{
    public class DataOperationException : Exception
    {
        public DataOperationException(string message, Exception error):base(message,error)
        {
        }
    }
}