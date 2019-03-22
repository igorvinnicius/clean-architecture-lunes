using System;

namespace lunes.Domain.Accounts
{
    public class Transfer : IOperation
    {
	    public string Name { get; }
	    public DateTime Date { get; }
	    public decimal Amount { get; }
	    public OperationNature OperationNature { get; }
	    public Guid FromAccountId { get; }
	    public Guid ToAccountId { get; }

		public Transfer(string name, OperationNature operationNature, decimal amount, Guid fromAccountId, Guid toAccountId)
		{
			Name = name;
			Date = DateTime.UtcNow;
			Amount = amount;
			FromAccountId = fromAccountId;
			ToAccountId = toAccountId;
			OperationNature = operationNature;
		}
	}
}
