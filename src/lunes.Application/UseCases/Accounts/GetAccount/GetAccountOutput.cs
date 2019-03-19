using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.GetAccount
{
    public class GetAccountOutput
    {
	    public Account Account { get; }

	    public GetAccountOutput(Account account)
	    {
		    Account = account;
	    }
    }
}
