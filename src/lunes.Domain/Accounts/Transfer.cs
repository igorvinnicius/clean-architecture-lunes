using System;

namespace lunes.Domain.Accounts
{
    public class Transfer : IOperation
    {
	    public string Name { get; }
	    public DateTime Date { get; }
	    public double Amount { get; }
	    public Guid FromAccountId { get; }
	    public Guid ToAccountId { get; }

		public Transfer(string name, double amount, Guid fromAccountId, Guid toAccountId)
		{
			Name = name;
			Date = DateTime.UtcNow;
			Amount = amount;
			FromAccountId = fromAccountId;
			ToAccountId = toAccountId;
		}
	}
}
