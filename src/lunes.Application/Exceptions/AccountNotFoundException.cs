namespace lunes.Application.Exceptions
{
    public class AccountNotFoundException : ApplicationException
    {
	    internal AccountNotFoundException(string message)
		    : base(message)
	    { }
	}
}
