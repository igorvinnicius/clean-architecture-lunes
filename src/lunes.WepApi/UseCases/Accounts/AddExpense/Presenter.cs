using lunes.Application.UseCases.Accounts.AddExpense;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.AddExpense
{
    public class Presenter
    {
	    public IActionResult ViewModel { get; private set; }

	    public void Fill(AddExpenseOutput output)
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
