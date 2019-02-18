namespace lunes.Application.UseCases.Accounts.MakeTransfer
{
    public class MakeTransferOutput
    {
	    public double FromAccountBalance { get; set; }

	    public double ToAccountBalance { get; set; }

	    public MakeTransferOutput(double fromAccountBalance, double toAccountBalance)
	    {
		    FromAccountBalance = fromAccountBalance;
		    ToAccountBalance = toAccountBalance;
	    }

	}
}
