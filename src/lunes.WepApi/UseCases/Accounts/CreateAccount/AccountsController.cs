using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.CreateAccount;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.CreateAccount
{
	[Route("api/[controller]")]
	public class AccountsController : Controller
	{
		private readonly ICreateAccountUseCase _createAccountUseCase;
		private readonly Presenter _presenter;


		public AccountsController(ICreateAccountUseCase createAccountUseCase)
		{
			_createAccountUseCase = createAccountUseCase;
			_presenter = new Presenter();
		}

	    [HttpPost]
	    public async Task<IActionResult> Post([FromBody]CreateAccountRequest createAccountRequest)
	    {
		    var output = await _createAccountUseCase.Run(createAccountRequest.Name);

			_presenter.Fill(output);

		    return _presenter.ViewModel;
		   
	    }
    }
}
