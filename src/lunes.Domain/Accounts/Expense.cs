using System;

namespace lunes.Domain.Accounts
{
    public class Expense : Operation
    {
	    public Expense() { }

	    public Expense(Guid accountId, string name, decimal amount) 
		    : base(accountId, name, amount)
		{
			OperationNature = OperationNature.Debit;
		}
	}
}
