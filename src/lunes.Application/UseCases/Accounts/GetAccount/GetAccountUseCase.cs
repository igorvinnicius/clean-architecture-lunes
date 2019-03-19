using System;
using System.Threading.Tasks;
using lunes.Domain.Accounts;

namespace lunes.Application.UseCases.Accounts.GetAccount
{
    public class GetAccountUseCase : IGetAccountUseCase
    {
	    public Task<GetAccountOutput> Run(Guid accountId)
	    {
		    throw new NotImplementedException();
	    }
    }
}
