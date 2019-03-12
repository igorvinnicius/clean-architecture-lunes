using System;

namespace lunes.WepApi.UseCases.Accounts.AddExpense
{
    public class AddExpenseRequest
    {
	    public Guid AccontId { get; set; }

	    public double Amount { get; set; }
    }
}
