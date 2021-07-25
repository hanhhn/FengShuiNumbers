using System;

namespace Coffee.Libs.Core.Exeptions
{
    public class BaseException : Exception
    {
        public string ErrorCode { get; set; }

        public BaseException(string msg) : base(msg)
        {
            ErrorCode = "1";
        }
    }
}
