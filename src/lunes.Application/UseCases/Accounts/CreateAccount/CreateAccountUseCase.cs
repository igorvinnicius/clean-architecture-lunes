using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.CreateAccount
{
    public class CreateAccountUseCase : ICreateAccountUseCase
    {
	    private readonly IAccountWriteOnlyRepository _accountWriteOnlyRepository;

		public CreateAccountUseCase(IAccountWriteOnlyRepository accountWriteOnlyRepository)
		{
			_accountWriteOnlyRepository = accountWriteOnlyRepository;
		}

		public async Task<CreateAccountOutput> Run(string accountName)
	    {
		    var newAccount = new Account(accountName);

		    await _accountWriteOnlyRepository.Add(newAccount);

			return new CreateAccountOutput(newAccount.Name, newAccount.Balance);
	    }
    }
}
