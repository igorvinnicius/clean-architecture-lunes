using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.ListAccounts;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.ListAccounts
{
	[Route("api/[controller]")]
	public class AccountsController : Controller
	{
		private readonly IListAccountsUseCase _listAccountsUseCase;
		private readonly Presenter _presenter;

		public AccountsController(IListAccountsUseCase listAccountsUseCase)
		{
			_listAccountsUseCase = listAccountsUseCase;
			_presenter = new Presenter();
		}

		[HttpGet("list", Name = "List" )]
	    public async Task<IActionResult> List()
	    {
			var listAccountsOutput = await _listAccountsUseCase.Run();

			_presenter.Fill(listAccountsOutput);

			return _presenter.ViewModel;

			//return Ok();
	    }
    }
}
