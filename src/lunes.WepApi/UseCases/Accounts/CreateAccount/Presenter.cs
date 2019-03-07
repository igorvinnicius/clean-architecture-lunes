using lunes.Application.UseCases.Accounts.CreateAccount;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.CreateAccount
{
    public class Presenter
    {
	    public IActionResult ViewModel { get; private set; }

	    public void Fill(CreateAccountOutput output)
	    {
		    if (output == null)
		    {
			    ViewModel = new NoContentResult();
				return;
		    }

		    ViewModel = new CreatedAtRouteResult("List", new { customerId = output.AccountId }, output);

		}
    }
}
