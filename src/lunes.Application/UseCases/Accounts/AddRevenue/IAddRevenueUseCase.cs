using System;
using System.Threading.Tasks;

namespace lunes.Application.UseCases.Accounts.AddRevenue
{
    public interface IAddRevenueUseCase
    {
	    Task<AddRevenueOutput> Run(Guid accountId, string name, decimal expectedBalance);

    }
}
