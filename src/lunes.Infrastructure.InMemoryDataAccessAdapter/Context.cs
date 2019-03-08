using System.Collections.ObjectModel;
using lunes.Domain.Accounts;

namespace lunes.Infrastructure.InMemoryDataAccessAdapter
{
    public class Context : IContext
    {
	    public Context()
	    {
			Seed();
	    }

	    public Collection<Account> Accounts { get; set; }

	    public void Seed()
	    {
			Accounts = new Collection<Account>();

			Accounts.Add(new Account("Account 1"));
	    }
    }
}
