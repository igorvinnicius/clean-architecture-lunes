using System;

namespace lunes.Application.UseCases.Accounts.AddRevenue
{
    public class AddRevenueOutput
    {
		public Guid AccountId { get; set; }

		public double Balance { get; }

		public AddRevenueOutput(Guid accountId, double balance)
		{
			AccountId = accountId;
			Balance = balance;
		}
	}
}
