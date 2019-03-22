using System;
using System.Threading.Tasks;

namespace lunes.Application.UseCases.Accounts.MakeTransfer
{
    public interface IMakeTransferUseCase
    {
	    Task<MakeTransferOutput> Run(string name, decimal amount, Guid fromAccountId, Guid toAccountId);

    }
}
