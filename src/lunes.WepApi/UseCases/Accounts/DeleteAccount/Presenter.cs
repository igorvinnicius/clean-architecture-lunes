using lunes.Application.UseCases.Accounts.DeleteAccount;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.DeleteAccount
{
    public class Presenter
    {
	    public IActionResult ViewModel { get; set; }

		public void Fill(DeleteAccountOutput output)
		{
			if (output == null)
			{
				ViewModel = new NoContentResult();
				return;
			}

			ViewModel = new ObjectResult(output);
		}
    }
}
