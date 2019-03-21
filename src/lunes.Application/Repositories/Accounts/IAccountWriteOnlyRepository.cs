using System;
using System.Threading.Tasks;
using lunes.Domain.Accounts;

namespace lunes.Application.Repositories.Accounts
{
    public interface IAccountWriteOnlyRepository
    {
	    Task Add(Account account);
	    Task Update(Account account);
	    Task Delete(Guid accountId);
    }
}
