namespace lunes.Application.UseCases.Accounts.MakeTransfer
{
    public class MakeTransferOutput
    {
	    public double Balance { get; }

	    public MakeTransferOutput(double balance)
	    {
		    Balance = balance;
	    }

	}
}
