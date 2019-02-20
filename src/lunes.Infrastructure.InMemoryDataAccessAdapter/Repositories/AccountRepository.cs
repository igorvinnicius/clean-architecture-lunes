using System;
using System.Linq;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Domain.Accounts;

namespace lunes.Infrastructure.InMemoryDataAccessAdapter.Repositories
{
    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
	    private readonly Context _context;

	    public AccountRepository(Context context)
	    {
		    _context = context;
	    }

	    public async Task<Account> GetAccount(Guid accountId)
	    {
		    var account =  _context.Accounts.SingleOrDefault(a => a.Id == accountId);

		    return await Task.FromResult<Account>(account);
	    }

	    public Task Add(Account account)
	    {
		    throw new NotImplementedException();
	    }

	    public Task Update(Account account)
	    {
		    throw new NotImplementedException();
	    }
    }
}
