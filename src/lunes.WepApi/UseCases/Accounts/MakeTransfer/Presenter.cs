using lunes.Application.UseCases.Accounts.MakeTransfer;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.MakeTransfer
{
    public class Presenter
    {
	    public IActionResult ViewModel { get; set; }

	    public void Fill(MakeTransferOutput output)
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
