using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.CreateAccount;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.CreateAccount
{
	[Route("api/[controller]")]
	public class AccountsController : Controller
	{
		private readonly ICreateAccountUseCase _createAccountUseCase;


		public AccountsController(ICreateAccountUseCase createAccountUseCase)
		{
			_createAccountUseCase = createAccountUseCase;
		}

	    [HttpPost]
	    public async Task<IActionResult> Post([FromBody]CreateAccountRequest createAccountRequest)
	    {

		    return await Task.FromResult(Ok());

		    //return Ok();
	    }
    }
}
