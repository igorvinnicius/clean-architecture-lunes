using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using lunes.Domain.Accounts;

namespace lunes.Application.Repositories.Accounts
{
    public interface IAccountReadOnlyRepository
    {
	    Task<Account> GetAccount(Guid accountId);

	    Task<IEnumerable<Account>> GetAllAccounts();
    }
}
