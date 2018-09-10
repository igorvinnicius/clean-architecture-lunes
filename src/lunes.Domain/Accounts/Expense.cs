using System;

namespace lunes.Domain.Accounts
{
    public class Expense : IOperation
    {
	    public string Name { get; }
	    public DateTime Date { get; }
	    public double Ammount { get; }

		public Expense(string name, double ammount)
		{
			Name = name;
			Ammount = ammount;
		}
	}
}
