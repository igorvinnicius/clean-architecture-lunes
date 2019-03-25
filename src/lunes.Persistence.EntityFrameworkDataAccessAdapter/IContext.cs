using System.Collections.ObjectModel;
using System.Threading.Tasks;
using lunes.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace lunes.Persistence.EntityFrameworkDataAccessAdapter
{
    public interface IContext
    {
	    DbSet<Account> Accounts { get; set; }

	    Task ExecuteSaveChangesAsync();

	    Task UpdateEntity(Account account);

	    Task DeleteEntity(Account account);


    }
}
