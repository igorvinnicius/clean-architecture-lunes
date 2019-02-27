using System.Collections.Generic;
using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.ListAccounts
{
    public class ListAccountsOutput
    {
	    public IEnumerable<Account> Accounts;

	    public ListAccountsOutput(IEnumerable<Account> accounts)
	    {
		    Accounts = accounts;
	    }
    }
}
