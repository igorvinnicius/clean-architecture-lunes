using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.UpdateAccount
{
    public class UpdateAccountUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;

	    public UpdateAccountUseCase(IAccountReadOnlyRepository accountReadOnlyRepository)
	    {
		    _accountReadOnlyRepository = accountReadOnlyRepository;
	    }

	    public async Task<UpdateAccountOutput> Run(Guid accountId, string accountName)
	    {
		    var account = await _accountReadOnlyRepository.GetAccount(accountId);

		    account.UpdateName(accountName);

			return new UpdateAccountOutput(account.Name);
	    }
    }
}
