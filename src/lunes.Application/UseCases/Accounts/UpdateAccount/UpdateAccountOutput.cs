using System;

namespace lunes.Application.UseCases.Accounts.UpdateAccount
{
    public class UpdateAccountOutput
    {
	    public Guid AccountId { get; set; }

	    public string AccountName { get; }

		public UpdateAccountOutput(Guid accountId, string accountName)
		{
			AccountId = accountId;
			AccountName = accountName;
		}
	}
}
