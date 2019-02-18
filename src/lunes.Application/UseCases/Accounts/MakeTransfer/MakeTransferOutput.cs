namespace lunes.Application.UseCases.Accounts.MakeTransfer
{
    public class MakeTransferOutput
    {
	    public double Balance { get; }

	    public double FromAccountBalance { get; set; }

	    public MakeTransferOutput(double balance)
	    {
		    FromAccountBalance = balance;
	    }

	}
}
