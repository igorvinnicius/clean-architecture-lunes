namespace lunes.Application.UseCases.Accounts.UpdateAccount
{
    public class UpdateAccountOutput
    {
	    public string AccountName { get; }

		public UpdateAccountOutput(string accountName)
		{
			AccountName = accountName;
		}
	}
}
