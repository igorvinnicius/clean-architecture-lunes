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
		    var fromAccount = await this._accountReadOnlyRepository.GetAccount(fromAccountId);

		    var toAccount = await this._accountReadOnlyRepository.GetAccount(toAccountId);

		    fromAccount.MakeTransfer(name, amount, toAccountId);

			toAccount.ReceiveTransfer(name, amount, fromAccountId);

		    await _accountRepository.Update(fromAccount);

			return new MakeTransferOutput(fromAccount.GetCurrentBalance(), toAccount.GetCurrentBalance());
		}
    }
}
