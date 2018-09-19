using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.CreateAccount
{
    public class CreateAccountUseCase
    {
	    private readonly IAccountRepository _accountRepository;

		public CreateAccountUseCase(IAccountRepository accountRepository)
		{
			_accountRepository = accountRepository;
		}

		public async Task<CreateAccountOutput> Run(string accountName)
	    {
		    var newAccount = new Account(accountName);

		    await _accountRepository.Add(newAccount);

			return new CreateAccountOutput(newAccount.Name, newAccount.Balance);
	    }
    }
}
