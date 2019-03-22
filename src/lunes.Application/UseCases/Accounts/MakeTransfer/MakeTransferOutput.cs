namespace lunes.Application.UseCases.Accounts.MakeTransfer
{
    public class MakeTransferOutput
    {
	    public decimal FromAccountBalance { get; set; }

	    public decimal ToAccountBalance { get; set; }

	    public MakeTransferOutput(decimal fromAccountBalance, decimal toAccountBalance)
	    {
		    FromAccountBalance = fromAccountBalance;
		    ToAccountBalance = toAccountBalance;
	    }

	}
}
