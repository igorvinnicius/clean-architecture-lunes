using System;

namespace lunes.Domain.Accounts
{
    public class Expense : IOperation
    {
	    public string Name { get; }
	    public DateTime Date { get; }
	    public double Amount { get; }
	    public OperationType OperationType { get; }

	    public Expense(string name, double amount)
		{
			Name = name;
			Amount = amount;
			Date = DateTime.Now;
			OperationType = OperationType.Debit;
		}
	}
}
