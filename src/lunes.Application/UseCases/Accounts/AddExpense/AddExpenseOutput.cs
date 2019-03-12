using System;

namespace lunes.Application.UseCases.Accounts.AddExpense
{
    public class AddExpenseOutput
    {
	    public Guid AccountId { get; set; }

	    public double Balance { get; }

	    public AddExpenseOutput(Guid accountId, double balance)
	    {
		    AccountId = accountId;
		    Balance = balance;
	    }
	}
}
