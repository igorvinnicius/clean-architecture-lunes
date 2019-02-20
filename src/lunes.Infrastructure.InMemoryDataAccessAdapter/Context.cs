using System.Collections.ObjectModel;
using lunes.Domain.Accounts;

namespace lunes.Infrastructure.InMemoryDataAccessAdapter
{
    public class Context
    {
	    public Collection<Account> Accounts { get; set; }
    }
}
