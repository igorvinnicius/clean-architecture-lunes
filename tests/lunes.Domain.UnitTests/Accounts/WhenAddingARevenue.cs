using lunes.Domain.Entities;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenAddingARevenue
    {
	    [Fact]
	    public void ShouldHaveABalanceOf100WhenAddingARevenueOf100AndCurrentBalanceIsZero()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue(100);

			Assert.Equal(100, sut.Balance);
	    }

	    [Fact]
	    public void ShouldHaveABalanceOf200WhenAddingARevenueOf100AndCurrentBalanceIs100()
	    {
		    var sut = new Account("Sut Account");
		    sut.AddRevenue(100);

			sut.AddRevenue(100);

		    Assert.Equal(200, sut.Balance);
	    }

	    [Fact]
	    public void AccountShouldKeepAllRevenues()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue(100);
			sut.AddRevenue(500);

		    var revenues = sut.GetRevenues();

			Assert.NotEmpty(revenues);
			Assert.Equal(2, revenues.Count);
	    }

    }
}
