using System;

namespace lunes.Application.Exceptions
{
    public class ApplicationException : Exception
    {
		internal ApplicationException(string businessMessage)
			: base(businessMessage)
		{
		}
	}
}
