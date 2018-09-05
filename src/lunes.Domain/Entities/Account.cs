﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace lunes.Domain.Entities
{
    public class Account : IEntity
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
		
	    public void AddRevenue(double value)
	    {
		    Balance += value;
	    }

	    public IReadOnlyCollection<IOperation> GetRevenues()
	    {
		    var revenues = _operations.ToList();
		    return new ReadOnlyCollection<IOperation>(revenues);
	    }
    }

	public interface IOperation
	{
	}
}
