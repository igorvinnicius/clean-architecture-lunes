using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Domain.Accounts;

namespace lunes.Infrastructure.InMemoryDataAccessAdapter.Repositories
{
    public class AccountRepository : IAccountReadOnlyRepository, IAccountWriteOnlyRepository
    {
	    private readonly Context _context;

	    public AccountRepository()
	    {
		    _context = new Context();
			
	    }

	    public async Task<Account> GetAccount(Guid accountId)
	    {
		    var account =  _context.Accounts.SingleOrDefault(a => a.Id == accountId);

		    return await Task.FromResult<Account>(account);
	    }

	    public async Task<IEnumerable<Account>> GetAllAccounts()
	    {
		    return await Task.FromResult<List<Account>>(_context.Accounts.ToList()); ;
	    }

	    public async Task Add(Account account)
	    {
		    _context.Accounts.Add(account);

		    await Task.CompletedTask;
	    }

	    public async Task Update(Account account)
	    {
		    var accountToUpdate = _context.Accounts.SingleOrDefault(a => a.Id == account.Id);
		    accountToUpdate = account;

		    await Task.CompletedTask;
	    }
    }
}
