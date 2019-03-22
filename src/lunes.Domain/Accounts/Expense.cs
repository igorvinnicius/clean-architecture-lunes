using System;

namespace lunes.Domain.Accounts
{
    public class Expense : IOperation
    {
	    public string Name { get; }
	    public DateTime Date { get; }
	    public decimal Amount { get; }
	    public OperationNature OperationNature { get; }

	    public Expense(string name, decimal amount)
		{
			Name = name;
			Amount = amount;
			Date = DateTime.Now;
			OperationNature = OperationNature.Debit;
		}
	}
}
