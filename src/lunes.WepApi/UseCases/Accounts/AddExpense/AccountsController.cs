using System;
using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.AddExpense;
using lunes.Application.UseCases.Accounts.CreateAccount;
using lunes.WepApi.UseCases.Accounts.CreateAccount;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.AddExpense
{
	[Route("api/[controller]")]
	public class AccountsController : Controller
    {
	    private readonly IAddExpenseUseCase _addExpenseUseCase;
	    private readonly Presenter _presenter;


	    public AccountsController(IAddExpenseUseCase addExpenseUseCase)
	    {
		    _addExpenseUseCase = addExpenseUseCase;
		    _presenter = new Presenter();
	    }

	    [HttpPatch("addexpense/{id}")]
	    public async Task<IActionResult> AddExpense(Guid id, [FromBody]AddExpenseRequest addExpenseRequest)
	    {
		    var output = await _addExpenseUseCase.Run(id, addExpenseRequest.Amount);

		    _presenter.Fill(output);

		    return _presenter.ViewModel;

	    }
	}
}
