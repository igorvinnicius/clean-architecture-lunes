using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.MakeTransfer
{
    public class MakeTransferUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
	    private readonly IAccountRepository _accountRepository;

	    public MakeTransferUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountRepository accountRepository)
	    {
		    _accountReadOnlyRepository = accountReadOnlyRepository;
		    _accountRepository = accountRepository;
	    }

		public async Task<MakeTransferOutput> Run(string name, double amount, Guid fromAccountId, Guid toAccountId)
	    {
		    var account = await this._accountReadOnlyRepository.GetAccount(fromAccountId);

			account.MakeTransfer(name, amount, toAccountId);

		    await _accountRepository.Update(account);

			return new MakeTransferOutput(account.GetCurrentBalance());
		}
    }
}
