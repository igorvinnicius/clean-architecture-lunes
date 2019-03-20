using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.GetAccount
{
    public class GetAccountUseCase : IGetAccountUseCase
    {
	    private readonly IAccountReadOnlyRepository _accountReadOnlyRepository;

	    public GetAccountUseCase(IAccountReadOnlyRepository accountReadOnlyRepository)
	    {
		    _accountReadOnlyRepository = accountReadOnlyRepository;
	    }

		public async Task<GetAccountOutput> Run(Guid accountId)
	    {
			var account = await _accountReadOnlyRepository.GetAccount(accountId);

			return  new GetAccountOutput(account);
		}
    }
}
