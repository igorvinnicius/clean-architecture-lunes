using System;
using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.AddRevenue;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.AddRevenue
{
	[Route("api/[controller]")]
	public class AccountsController : Controller
	{
		private readonly IAddRevenueUseCase _addRevenueUseCase;
		private readonly Presenter _presenter;


		public AccountsController(IAddRevenueUseCase addRevenueUseCase)
		{
			_addRevenueUseCase = addRevenueUseCase;
			_presenter = new Presenter();
		}

		[HttpPatch("addrevenue/{id}")]
		public async Task<IActionResult> AddExpense(Guid id, [FromBody]AddRevenueRequest addRevenueRequest)
		{
			var output = await _addRevenueUseCase.Run(id, addRevenueRequest.Name, addRevenueRequest.Amount);

			_presenter.Fill(output);

			return _presenter.ViewModel;

		}
	}
}
