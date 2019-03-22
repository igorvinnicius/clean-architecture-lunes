using System;

namespace lunes.Domain.Accounts
{
	public class Revenue : IOperation
	{
		public string Name { get; }
		public DateTime Date { get; }
		public decimal Amount { get; }
		public OperationNature OperationNature { get; private set; }

		public Revenue(string name, decimal amount)
		{
			Name = name;
			Date = DateTime.Now;
			Amount = amount;
			OperationNature = OperationNature.Credit;
		}
	}
}
