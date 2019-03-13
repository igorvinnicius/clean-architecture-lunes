using lunes.Application.UseCases.Accounts.AddRevenue;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.AddRevenue
{
	public class Presenter
	{
		public IActionResult ViewModel { get; private set; }

		public void Fill(AddRevenueOutput output)
		{
			if (output == null)
			{
				ViewModel = new NoContentResult();
				return;
			}

			ViewModel = new ObjectResult(new { AccountId = output.AccountId, Balance = output.Balance });
		}
	}
}
