using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace lunes.Domain.Accounts
{
    public class Account : IEntity, IAggregateRoot
    {
	    public Guid Id { get; }
	    public string Name { get; private set; }
	    public double Balance { get; private set; }

	    private ICollection<IOperation> _operations;

		public Account(string name)
		{
			Id = Guid.NewGuid();
			Name = name;
			Balance = 0;

			_operations = new List<IOperation>();
		}
		
	    public void AddRevenue(string name, double amount)
	    {
		    var revenue = new Revenue(name, amount);
			_operations.Add(revenue);

		    Balance += revenue.Amount;
	    }

	    public IReadOnlyCollection<IOperation> GetRevenues()
	    {
		    var revenues = _operations.Where(o => o is Revenue).ToList();
		    return new ReadOnlyCollection<IOperation>(revenues);
	    }

	    public double GetCurrentBalance()
	    {
		    var totalRevenues = GetRevenues().Sum(r => r.Amount);
		    var totalExpenses = GetExpenses().Sum(e => e.Amount);
		    var totalTransfers = GetTransfers().Sum(e => e.Amount);

			return totalRevenues - (totalExpenses + totalTransfers);
	    }

	    public IReadOnlyCollection<IOperation> GetExpenses()
	    {
			var expenses = _operations.Where(o => o is Expense).ToList();
		    return new ReadOnlyCollection<IOperation>(expenses);
		}

	    public IReadOnlyCollection<IOperation> GetTransfers()
	    {
		    var transfers = _operations.Where(o => o is Transfer).ToList();
		    return new ReadOnlyCollection<IOperation>(transfers);
	    }

		public void AddExpense(string name, double amount)
	    {
		    var expense = new Expense(name, amount);
			_operations.Add(expense);
	    }

	    public void UpdateName(string name)
	    {
		    Name = name;
	    }

	    public void MakeTransfer(string name, double amount, Guid toAccountId)
	    {
			var transfer = new Transfer(name, amount, this.Id, toAccountId);
			_operations.Add(transfer);
		   
	    }
    }

	

	
}
