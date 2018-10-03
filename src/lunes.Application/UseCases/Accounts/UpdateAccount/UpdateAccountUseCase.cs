using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.UpdateAccount
{
    public class UpdateAccountUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
	    private readonly IAccountRepository _accountRepository;

		public UpdateAccountUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountRepository accountRepository)
	    {
		    _accountReadOnlyRepository = accountReadOnlyRepository;
		    this._accountRepository = accountRepository;
	    }

	    public async Task<UpdateAccountOutput> Run(Guid accountId, string accountName)
	    {
		    var account = await _accountReadOnlyRepository.GetAccount(accountId);

		    account.UpdateName(accountName);

		    await _accountRepository.Update(account);

			return new UpdateAccountOutput(account.Name);
	    }
    }
}
