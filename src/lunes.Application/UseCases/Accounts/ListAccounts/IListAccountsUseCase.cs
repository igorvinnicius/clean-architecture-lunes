using System.Collections.Generic;
using System.Threading.Tasks;
using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.ListAccounts
{
    public interface IListAccountsUseCase
    {
	    Task<ListAccountsOutput> Run();

    }
}
