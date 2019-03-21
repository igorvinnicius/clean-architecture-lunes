using System;
using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.DeleteAccount;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.DeleteAccount
{
	[Route("api/[controller]")]
	public class AccountsController
    {
	    private readonly IDeleteAccountUseCase _deleteAccountsUseCase;
	    private readonly Presenter _presenter;

	    public AccountsController(IDeleteAccountUseCase getAccountUseCase)
	    {
		    _deleteAccountsUseCase = getAccountUseCase;
		    _presenter = new Presenter();
	    }

	    [HttpDelete("delete/{id}", Name = "DeleteAccount")]
	    public async Task<IActionResult> Delete(Guid id)
	    {
		    var deleteAccountOutput = await _deleteAccountsUseCase.Run(id);

		    _presenter.Fill(deleteAccountOutput);

		    return _presenter.ViewModel;

	    }
	}
}
