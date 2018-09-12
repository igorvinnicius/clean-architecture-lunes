using lunes.Domain.Accounts;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenAddingARevenue
    {
	    [Fact]
	    public void ShouldHaveABalanceOf100WhenAddingARevenueOf100AndCurrentBalanceIsZero()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", 100);

			Assert.Equal(100, sut.GetCurrentBalance());
	    }

	    [Fact]
	    public void ShouldHaveABalanceOf200WhenAddingARevenueOf100AndCurrentBalanceIs100()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", 100);
			sut.AddRevenue("Revenue 2", 100);

		    Assert.Equal(200, sut.GetCurrentBalance());
	    }

	    [Fact]
	    public void AccountShouldKeepAllRevenues()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", 100);
			sut.AddRevenue("Revenue 2", 500);

		    var revenues = sut.GetRevenues();

			Assert.NotEmpty(revenues);
			Assert.Equal(2, revenues.Count);
	    }

	    [Theory]
	    [InlineData(100, 20.80, 120.80)]
	    [InlineData(300, 260, 560)]
	    [InlineData(3000, 250.86, 3250.86)]
	    [InlineData(-2000, 4020, 2020)]
	    public void ShouldCalculateBalanceCorrectly(double initialBalance, double expense, double expectedBalance)
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", initialBalance);

		    sut.AddRevenue("Revenue", expense);

		    Assert.Equal(expectedBalance, sut.GetCurrentBalance());
	    }

	}
}
