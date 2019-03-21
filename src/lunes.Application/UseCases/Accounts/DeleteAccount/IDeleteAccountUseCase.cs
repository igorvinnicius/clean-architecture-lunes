using System;
using System.Threading.Tasks;

namespace lunes.Application.UseCases.Accounts.DeleteAccount
{
    public interface IDeleteAccountUseCase
    {
	    Task<DeleteAccountOutput> Run(Guid accountId);
    }
}
