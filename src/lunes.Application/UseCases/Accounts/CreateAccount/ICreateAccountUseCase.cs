using System.Threading.Tasks;

namespace lunes.Application.UseCases.Accounts.CreateAccount
{
    public interface ICreateAccountUseCase
    {
	    Task<CreateAccountOutput> Run(string accountName);

    }
}
