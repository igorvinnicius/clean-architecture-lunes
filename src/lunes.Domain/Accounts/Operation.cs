using System;

namespace lunes.Domain.Accounts
{
    public abstract  class Operation : IOperation
    {
	    public Guid Id { get; protected set; }
	    public Guid AccountId { get; private set; }
	    public string Name { get; protected set; }
	    public DateTime Date { get; protected set; }
	    public decimal Amount { get; protected set; }
	    public OperationNature OperationNature { get; protected set; }

	    protected Operation() { }

	    protected Operation(Guid accountId, string name, decimal amount)
	    {
			Id = Guid.NewGuid();
			AccountId = accountId;
		    Name = name;
		    Date = DateTime.UtcNow;
		    Amount = amount;
	    }
    }
}
