using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.AddRevenue
{
    public class AddRevenueUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
	    private readonly IAccountRepository _accountRepository;

	    public AddRevenueUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountRepository accountRepository)
	    {
		    this._accountReadOnlyRepository = accountReadOnlyRepository;
		    this._accountRepository = accountRepository;
	    }

		public async Task<AddRevenueOutput> Run(Guid accountId, double expectedBalance)
	    {
		    var account = await this._accountReadOnlyRepository.GetAccount(accountId);

			account.AddRevenue("New Revenue", expectedBalance);

		    await _accountRepository.Update(account);

			return new AddRevenueOutput(account.GetCurrentBalance());
	    }
    }
}
