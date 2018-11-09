using lunes.Domain.Accounts;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenMakingATransfer
    {
	    [Fact]
	    public void ShouldCreateAExpenseInFromAccount()
	    {

	    }

	    private Account CreateAccount()
	    {
			return new Account("New Account");
	    }

    }
}
