using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.UpdateAccount
{
    public class UpdateAccountUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReaOnlyRepository;

	    public UpdateAccountUseCase(IAccountReadOnlyRepository accountReadOnlyRepository)
	    {
		    _accountReaOnlyRepository = accountReadOnlyRepository;
	    }

	    public async Task<UpdateAccountOutput> Run(Guid accountId, string accountName)
	    {
		    var account = await _accountReaOnlyRepository.GetAccount(accountId);

		    account.UpdateName(accountName);

			return new UpdateAccountOutput();
	    }
    }
}
