using lunes.Application.UseCases.Accounts.ListAccounts;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.ListAccounts
{
    public class Presenter
    {
	    public IActionResult ViewModel { get; private set; }

	    public void Fill(ListAccountsOutput output)
	    {
		    if (output == null)
		    {
			    ViewModel = new NoContentResult();
			    return;
		    }

			ViewModel = new ObjectResult(output.Accounts);
		}
    }
}
