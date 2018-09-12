using lunes.Domain.Accounts;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenAddingAnExpense
    {
	    [Fact]
	    public void ShouldHaveABalanceOf100WhenAddingAnExpenseOf100AndCurrentBalanceIs200()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", 200);

		    sut.AddExpense("Expense", 100);

			Assert.Equal(100, sut.GetCurrentBalance());
	    }

	    [Fact]
	    public void ShouldHaveABalanceOfZeroWhenAddingAnExpenseOf200AndCurrentBalanceIs200()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", 200);

		    sut.AddExpense("Expense", 200);

		    Assert.Equal(0, sut.GetCurrentBalance());
	    }

		[Fact]
	    public void ShouldHaveABalanceOfMinus100WhenAddingAnExpenseOf300AndCurrentBalanceIs200()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", 200);

		    sut.AddExpense("Expense", 300);

		    Assert.Equal(-100, sut.GetCurrentBalance());
	    }

	}
}
