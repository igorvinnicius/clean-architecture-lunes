using lunes.Application.UseCases.Account.CreateAccount;
using Xunit;

namespace lunes.UseCases.UnitTests.Account
{
    public class WhenCreatingAnAccount
    {
	    [Fact]
	    public void ShouldHasANameAndBalanceZero()
	    {
		    var expectedAccountName = "Use Case Account";
		    var expectedBalance = 0;

		    var sut = new CreateAccountUseCase();


	    }

    }
}
