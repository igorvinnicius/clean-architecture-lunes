using lunes.Application.UseCases.Accounts.UpdateAccount;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.UpdateAccount
{
    public class Presenter
    {
	    public IActionResult ViewModel { get; set; }

	    public void Fill(UpdateAccountOutput output)
	    {
		    if (output == null)
		    {
			    ViewModel = new NoContentResult();
			    return;
		    }

			ViewModel = new ObjectResult(new {AccountId = output.AccountId, Name = output.AccountName});
		}
    }
}
