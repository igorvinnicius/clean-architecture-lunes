namespace lunes.Application.UseCases.Accounts.CreateAccount
{
    public class CreateAccountOutput
    {
	    public string AccountName { get; }
	    public double AccountBalance { get; }

		public CreateAccountOutput(string accountName, double accountBalance)
		{
			AccountName = accountName;
			AccountBalance = accountBalance;
		}
	}
}
