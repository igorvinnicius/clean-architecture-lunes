using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.UpdateAccount;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.UpdateAccount
{
	[Route("api/[controller]")]
	public class AccountsController : Controller
	{
		private readonly IUpdateAccountUseCase _updateAccountUseCase;
		private readonly Presenter _presenter;

	    public AccountsController(IUpdateAccountUseCase updateAccountUseCase)
	    {
		    _updateAccountUseCase = updateAccountUseCase;
			_presenter = new Presenter();
	    }

		[HttpPatch("Update")]
	    public async Task<IActionResult> Update([FromBody]UpdateAccountRequest updateAccountRequest)
	    {
		    return await Task.FromResult(Ok());
	    }
	}
}
