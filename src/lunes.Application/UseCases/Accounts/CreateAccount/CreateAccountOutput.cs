using System;

namespace lunes.Application.UseCases.Accounts.CreateAccount
{
    public class CreateAccountOutput
    {
	    public Guid AccountId { get; }
	    public string AccountName { get; }
	    public double AccountBalance { get; }

		public CreateAccountOutput(Guid accountId, string accountName, double accountBalance)
		{
			AccountId = accountId;
			AccountName = accountName;
			AccountBalance = accountBalance;
		}
	}
}
