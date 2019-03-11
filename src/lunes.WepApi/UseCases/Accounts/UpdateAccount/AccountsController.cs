using System;
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

		[HttpPut("{id}")]
	    public async Task<IActionResult> Update(Guid id, [FromBody]UpdateAccountRequest updateAccountRequest)
	    {
		    var output = await _updateAccountUseCase.Run(id, updateAccountRequest.Name);

			_presenter.Fill(output);

			return _presenter.ViewModel;
	    }
	}
}
