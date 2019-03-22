using System;

namespace lunes.WepApi.UseCases.Accounts.MakeTransfer
{
    public class MakeTransferRequest
    {
	    public Guid FromAccountId { get; set; }

	    public Guid ToAccountId { get; set; }

	    public string Name { get; set; }

	    public decimal Amount { get; set; }
    }
}
