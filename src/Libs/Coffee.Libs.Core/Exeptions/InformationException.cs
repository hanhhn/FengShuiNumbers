using System;

namespace Coffee.Libs.Core.Exeptions
{
	public class InformationException : BaseException
	{
		public InformationException(string msg) : base(msg)
		{
			ErrorCode = "2";
		}
	}
}