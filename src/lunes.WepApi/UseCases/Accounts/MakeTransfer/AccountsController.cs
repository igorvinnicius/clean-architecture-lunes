using System;
using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.MakeTransfer;
using Microsoft.AspNetCore.Mvc;

namespace lunes.WepApi.UseCases.Accounts.MakeTransfer
{
	[Route("api/[controller]")]
	public class AccountsController : Controller
    {
	    private readonly IMakeTransferUseCase _makeTransferUseCase;
	    private readonly Presenter _presenter;


	    public AccountsController(IMakeTransferUseCase makeTransferUseCase)
	    {
		    _makeTransferUseCase = makeTransferUseCase;
		    _presenter = new Presenter();
	    }

	    [HttpPatch("maketransfer")]
	    public async Task<IActionResult> AddMakeTransfer([FromBody]MakeTransferRequest makeTransferRequest)
	    {
		    var output = await _makeTransferUseCase.Run(makeTransferRequest.Name, makeTransferRequest.Amount, makeTransferRequest.FromAccountId, makeTransferRequest.ToAccountId);

		    _presenter.Fill(output);

		    return _presenter.ViewModel;

	    }
	}
}
