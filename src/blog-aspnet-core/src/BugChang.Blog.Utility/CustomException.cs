using System;
using System.Collections.Generic;
using System.Text;

namespace BugChang.Blog.Utility
{

    public enum CustomExceptionCode
    {
        NotFound = 0,
        AlreadyExist = 1,

    }
    public class CustomException : Exception
    {
        public CustomException(CustomExceptionCode exceptionCode, string message)
        {
            ExceptionCode = exceptionCode;
            Message = message;
        }
        public CustomExceptionCode ExceptionCode { get; }

        public override string Message { get; }

    }
}
