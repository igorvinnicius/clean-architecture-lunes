using lunes.Domain.Entities;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenAnAccountIsCreated
    {
	    [Fact]
	    public void ShoudHaveACurrentBalanceZero()
	    {
		    var sut = new Account();

			Assert.Equal(0, sut.Balance);
	    }


    }
}
