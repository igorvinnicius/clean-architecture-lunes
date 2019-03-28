using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace lunes.Domain.Accounts
{
    public class Account : IEntity, IAggregateRoot
    {
	    public Guid Id { get; private set; }
	    public string Name { get; private set; }
	    public decimal Balance { get; private set; }

	    public ICollection<Operation> Operations => _operations;

	    private ICollection<Operation> _operations;

		public Account(string name)
		{
			Id = Guid.NewGuid();
			Name = name;
			Balance = 0;

			_operations = new List<Operation>();
		}
		
	    public void AddRevenue(string name, decimal amount)
	    {
		    var revenue = new Revenue(this.Id, name, amount);
			_operations.Add(revenue);

		    Balance += revenue.Amount;
	    }

	    public IReadOnlyCollection<IOperation> GetRevenues()
	    {
		    var revenues = _operations.Where(o => o is Revenue).ToList();
		    return new ReadOnlyCollection<Operation>(revenues);
	    }

	    public decimal GetCurrentBalance()
	    {
		    var creditOperations = _operations.Where(o => o.OperationNature == OperationNature.Credit).Sum(o => o.Amount);
		    var debitOperations = _operations.Where(o => o.OperationNature == OperationNature.Debit).Sum(o => o.Amount);
		
		    return creditOperations - debitOperations;
	    }

	    public IReadOnlyCollection<IOperation> GetExpenses()
	    {
			var expenses = _operations.Where(o => o is Expense).ToList();
		    return new ReadOnlyCollection<Operation>(expenses);
		}

	    public IReadOnlyCollection<IOperation> GetTransfers()
	    {
		    var transfers = _operations.Where(o => o is Transfer).ToList();
		    return new ReadOnlyCollection<Operation>(transfers);
	    }

		public void AddExpense(string name, decimal amount)
	    {
		    var expense = new Expense(this.Id, name, amount);
			_operations.Add(expense);
	    }

	    public void UpdateName(string name)
	    {
		    Name = name;
	    }

	    public void MakeTransfer(string name, decimal amount, Guid toAccountId)
	    {
			var transfer = new Transfer(this.Id, name, OperationNature.Debit, amount, this.Id, toAccountId);
			_operations.Add(transfer);
		   
	    }

	    public void ReceiveTransfer(string name, decimal amount, Guid fromAccountId)
	    {
			var transfer = new Transfer(this.Id, name, OperationNature.Credit, amount, fromAccountId, this.Id);
			_operations.Add(transfer);
		}
    }

	

	
}
