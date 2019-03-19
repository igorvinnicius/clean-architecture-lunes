using System;
using System.Threading.Tasks;
using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.GetAccount
{
    public interface IGetAccountUseCase
    {
	    Task<GetAccountOutput> Run(Guid accountId);
    }
}
