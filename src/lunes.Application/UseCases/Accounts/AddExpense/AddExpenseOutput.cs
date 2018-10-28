namespace lunes.Application.UseCases.Accounts.AddExpense
{
    public class AddExpenseOutput
    {
	    public double Balance { get; }

	    public AddExpenseOutput(double balance)
	    {
		    Balance = balance;
	    }
	}
}
