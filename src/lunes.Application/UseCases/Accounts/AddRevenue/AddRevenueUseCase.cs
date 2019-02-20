using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;

namespace lunes.Application.UseCases.Accounts.AddRevenue
{
    public class AddRevenueUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;
	    private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

	    public AddRevenueUseCase(IAccountReadOnlyRepository accountReadOnlyRepository, IAccountWriteOnlyRepository accountWriteOnlyRepository)
	    {
		    this._accountReadOnlyRepository = accountReadOnlyRepository;
		    this._accountWriteOnlyRepository = accountWriteOnlyRepository;
	    }

		public async Task<AddRevenueOutput> Run(Guid accountId, double expectedBalance)
	    {
		    var account = await this._accountReadOnlyRepository.GetAccount(accountId);

			account.AddRevenue("New Revenue", expectedBalance);

		    await _accountWriteOnlyRepository.Update(account);

			return new AddRevenueOutput(account.GetCurrentBalance());
	    }
    }
}
