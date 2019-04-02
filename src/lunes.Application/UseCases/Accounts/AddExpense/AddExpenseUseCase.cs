using System;
using System.Threading.Tasks;
using lunes.Application.Exceptions;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.AddExpense
{
	public class AddExpenseUseCase : IAddExpenseUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
	    private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

		public AddExpenseUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountWriteOnlyRepository accountWriteOnlyRepository)
		{
			_accountReadOnlyRepository = accountReadOnlyRepository;
			_accountWriteOnlyRepository = accountWriteOnlyRepository;
		}

		public async Task<AddExpenseOutput> Run(Guid accountId, string name, decimal value)
	    {
			var account = await this._accountReadOnlyRepository.GetAccount(accountId);

			if(account == null)
				throw new AccountNotFoundException("Account not found.");

		    account.AddExpense(name, value);

		    await _accountWriteOnlyRepository.Update(account);

		    return new AddExpenseOutput(account.Id, account.GetCurrentBalance());
		}
    }
}
