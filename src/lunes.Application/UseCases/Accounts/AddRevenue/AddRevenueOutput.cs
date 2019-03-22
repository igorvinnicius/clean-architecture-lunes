using System;

namespace lunes.Application.UseCases.Accounts.AddRevenue
{
    public class AddRevenueOutput
    {
		public Guid AccountId { get; set; }

		public decimal Balance { get; }

		public AddRevenueOutput(Guid accountId, decimal balance)
		{
			AccountId = accountId;
			Balance = balance;
		}
	}
}
