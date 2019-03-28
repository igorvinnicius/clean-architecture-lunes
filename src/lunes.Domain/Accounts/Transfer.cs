using System;

namespace lunes.Domain.Accounts
{
    public class Transfer : Operation
    {
	    public Guid FromAccountId { get; protected set; }
	    public Guid ToAccountId { get; protected set; }

	    public Transfer() { }

		public Transfer(Guid accountId, string name, OperationNature operationNature, decimal amount, Guid fromAccountId, Guid toAccountId) 
			: base(accountId, name, amount)
		{
			FromAccountId = fromAccountId;
			ToAccountId = toAccountId;
			OperationNature = operationNature;
		}
	}
}
