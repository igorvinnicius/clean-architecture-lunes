using System.Collections.ObjectModel;
using lunes.Domain.Accounts;

namespace lunes.Infrastructure.InMemoryDataAccessAdapter
{
    public interface IContext
    {
	    Collection<Account> Accounts { get; set; }
	}
}
