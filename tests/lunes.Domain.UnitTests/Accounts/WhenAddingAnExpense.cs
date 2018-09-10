using lunes.Domain.Accounts;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenAddingAnExpense
    {
	    [Fact]
	    public void ShouldHaveABalanceOf100WhenAddingARevenueAndCurrentBalanceIs200()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", 200);

		    sut.AddExpense("Expense", 100);

			Assert.Equal(100, sut.GetCurrentBalance());
	    }

    }
}
