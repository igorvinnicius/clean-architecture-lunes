using System.Threading.Tasks;

namespace lunes.Application.UseCases.Accounts.AddRevenue
{
    public class AddRevenueUseCase
    {
	    public async Task<AddRevenueOutput> Run(double expectedBalance)
	    {
		   return new AddRevenueOutput(0);
	    }
    }
}
