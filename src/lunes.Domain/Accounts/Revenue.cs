using System;

namespace lunes.Domain.Accounts
{
	public class Revenue : IOperation
	{
		public string Name { get; }
		public DateTime Date { get; }
		public double Ammount { get; }

		public Revenue(string name, double ammount)
		{
			Name = name;
			Ammount = ammount;
		}
	}
}
