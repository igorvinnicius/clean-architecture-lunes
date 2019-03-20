using lunes.Application.UseCases.Accounts.GetAccount;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.GetAccount
{
    public class Presenter
    {
	    public IActionResult ViewModel { get; private set; }

	    public void Fill(GetAccountOutput output)
	    {
		    if (output == null)
		    {
			    ViewModel = new NoContentResult();
			    return;
		    }

			ViewModel = new ObjectResult(output.Account);

		}
    }
}
