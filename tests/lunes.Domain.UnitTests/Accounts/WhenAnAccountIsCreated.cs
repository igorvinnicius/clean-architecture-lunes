using lunes.Domain.Accounts;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenAnAccountIsCreated
    {
	    [Fact]
	    public void ShoudHaveACurrentBalanceZero()
	    {
		    var sut = new Account("Sut Account");

			Assert.Equal(0, sut.GetCurrentBalance());
	    }

    }
}
