using System;

namespace lunes.Application.UseCases.Accounts.CreateAccount
{
    public class CreateAccountOutput
    {
	    public Guid AccountId { get; }
	    public string AccountName { get; }
	    public decimal AccountBalance { get; }

		public CreateAccountOutput(Guid accountId, string accountName, decimal accountBalance)
		{
			AccountId = accountId;
			AccountName = accountName;
			AccountBalance = accountBalance;
		}
	}
}
