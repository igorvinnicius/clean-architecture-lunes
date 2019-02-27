using System;
using System.Threading.Tasks;


namespace lunes.Application.UseCases.Accounts.UpdateAccount
{
    public interface IUpdateAccountUseCase
    {
	    Task<UpdateAccountOutput> Run(Guid accountId, string accountName);
    }
}
