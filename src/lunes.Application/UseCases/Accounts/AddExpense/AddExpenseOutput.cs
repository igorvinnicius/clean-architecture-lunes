using System;
using lunes.Application.UseCases.Common;

namespace lunes.Application.UseCases.Accounts.AddExpense
{
    public class AddExpenseOutput : Output
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
