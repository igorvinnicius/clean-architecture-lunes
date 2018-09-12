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

	    [Theory]
		[InlineData(100, 20.80, 79.20)]
	    [InlineData(300, 260, 40)]
	    [InlineData(3000, 250.86, 2749.14)]
	    [InlineData(2000, 4020, -2020)]
		public void ShouldCalculateBalanceCorrectly(double initialBalance, double expense, double expectedBalance)
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", initialBalance);

		    sut.AddExpense("Expense", expense);

		    Assert.Equal(expectedBalance, sut.GetCurrentBalance());
		}

    }
}
