using System.Threading.Tasks;
using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.CreateAccount
{
    public class CreateAccountUseCase
    {
	    public async Task<CreateAccountOutput> Run(string accountName)
	    {
		    var newAccount = new Account(accountName);

			return new CreateAccountOutput(newAccount.Name, newAccount.Balance);
	    }
    }
}
