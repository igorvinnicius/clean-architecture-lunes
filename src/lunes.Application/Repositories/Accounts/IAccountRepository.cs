using System.Threading.Tasks;
using lunes.Domain.Accounts;

namespace lunes.Application.Repositories.Accounts
{
    public interface IAccountRepository
    {
	    Task Add(Account account);
	    Task Update(Account account);
	}
}
