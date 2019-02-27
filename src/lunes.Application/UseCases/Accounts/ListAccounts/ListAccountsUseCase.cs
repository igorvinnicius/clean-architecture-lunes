using System.Collections.Generic;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.ListAccounts
{
    public class ListAccountsUseCase : IListAccountsUseCase
	{
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;

	    public ListAccountsUseCase(IAccountReadOnlyRepository accountReadOnlyRepository)
	    {
		    _accountReadOnlyRepository = accountReadOnlyRepository;
	    }

		public async Task<ListAccountsOutput> Run()
		{
			var accounts = await _accountReadOnlyRepository.GetAllAccounts();

			return new ListAccountsOutput(accounts);
		}
    }
}
