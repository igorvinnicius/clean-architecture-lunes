using System;
using System.Threading.Tasks;
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

		public async Task<AddExpenseOutput> Run(Guid accountId, double value)
	    {
			var account = await this._accountReadOnlyRepository.GetAccount(accountId);

		    account.AddExpense("New Expense", value);

		    await _accountWriteOnlyRepository.Update(account);

		    return new AddExpenseOutput(account.Id, account.GetCurrentBalance());
		}
    }
}
