using System.Collections.Generic;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.ListAccounts
{
    public class ListAccountsUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;

	    public ListAccountsUseCase(IAccountReadOnlyRepository accountReadOnlyRepository)
	    {
		    _accountReadOnlyRepository = accountReadOnlyRepository;
	    }

		public async Task<IEnumerable<Account>> Run()
		{
			return await _accountReadOnlyRepository.GetAllAccounts();
		}
    }
}
