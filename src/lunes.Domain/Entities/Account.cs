using System;

namespace lunes.Domain.Entities
{
    public class Account : IEntity
    {
	    public Guid Id { get; }
	    public string Name { get; private set; }
	    public double Balance { get; private set; }

		public Account(string name)
		{
			Id = Guid.NewGuid();
			Name = name;
			Balance = 0;
		}
		
	    public void AddRevenue(double value)
	    {
		    Balance += 100;
	    }
    }
}
