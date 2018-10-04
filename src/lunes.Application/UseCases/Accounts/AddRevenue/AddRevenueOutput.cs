namespace lunes.Application.UseCases.Accounts.AddRevenue
{
    public class AddRevenueOutput
    {
	    public double Balance { get; }

		public AddRevenueOutput(double balance)
		{
			Balance = balance;
		}
	}
}
