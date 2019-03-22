using System;

namespace lunes.Application.UseCases.Accounts.AddExpense
{
    public class AddExpenseOutput
    {
	    public Guid AccountId { get; set; }

	    public decimal Balance { get; }

	    public AddExpenseOutput(Guid accountId, decimal balance)
	    {
		    AccountId = accountId;
		    Balance = balance;
	    }
	}
}
