using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.AddRevenue;

namespace lunes.Application.UseCases.Accounts.AddExpense
{
    public class AddExpenseUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
	    private readonly IAccountRepository _accountRepository;

		public AddExpenseUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountRepository accountRepository)
		{
			_accountReadOnlyRepository = accountReadOnlyRepository;
			_accountRepository = accountRepository;
		}

		public async Task<AddExpenseOutput> Run(Guid accountId, double value)
	    {
			var account = await this._accountReadOnlyRepository.GetAccount(accountId);

		    account.AddExpense("New Expense", value);

		    await _accountRepository.Update(account);

		    return new AddExpenseOutput(account.GetCurrentBalance());
		}
    }
}
