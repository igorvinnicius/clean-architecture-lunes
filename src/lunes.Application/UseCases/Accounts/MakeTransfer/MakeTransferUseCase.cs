using System;
using System.Threading.Tasks;
using lunes.Application.Exceptions;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.MakeTransfer
{
    public class MakeTransferUseCase : IMakeTransferUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
	    private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

	    public MakeTransferUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountWriteOnlyRepository accountWriteOnlyRepository)
	    {
		    _accountReadOnlyRepository = accountReadOnlyRepository;
		    _accountWriteOnlyRepository = accountWriteOnlyRepository;
	    }

		public async Task<MakeTransferOutput> Run(string name, decimal amount, Guid fromAccountId, Guid toAccountId)
	    {
		    var fromAccount = await this._accountReadOnlyRepository.GetAccount(fromAccountId);

		    if (fromAccount == null)
			    throw new AccountNotFoundException("Account not found.");

			var toAccount = await this._accountReadOnlyRepository.GetAccount(toAccountId);

			if (toAccount == null)
				throw new AccountNotFoundException("Account not found.");

			fromAccount.MakeTransfer(name, amount, toAccountId);

			toAccount.ReceiveTransfer(name, amount, fromAccountId);

		    await _accountWriteOnlyRepository.Update(fromAccount);

			return new MakeTransferOutput(fromAccount.GetCurrentBalance(), toAccount.GetCurrentBalance());
		}
    }
}
