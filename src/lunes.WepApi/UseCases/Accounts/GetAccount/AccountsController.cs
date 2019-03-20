using System;
using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.GetAccount;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.GetAccount
{
	[Route("api/[controller]")]
	public class AccountsController
    {
	    private readonly IGetAccountUseCase _getAccountsUseCase;
	    private readonly Presenter _presenter;

	    public AccountsController(IGetAccountUseCase getAccountUseCase)
	    {
		    _getAccountsUseCase = getAccountUseCase;
		    _presenter = new Presenter();
	    }

	    [HttpGet("{id}", Name = "GetAccount")]
	    public async Task<IActionResult> GetAccount(Guid id)
	    {
		    var getAccountOutput = await _getAccountsUseCase.Run(id);

		    _presenter.Fill(getAccountOutput);

		    return _presenter.ViewModel;

	    }

	}
}
