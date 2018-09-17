using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.CreateAccount;
using Xunit;

namespace lunes.UseCases.UnitTests.Account
{
    public class WhenCreatingAnAccount
    {
	    [Fact]
	    public async Task ShouldHasANameAndBalanceZero()
	    {
		    var expectedAccountName = "Use Case Account";
		    double expectedBalance = 0;

		    var sut = new CreateAccountUseCase();

		    var actualAccountOutput = await sut.Run(expectedAccountName);

			Assert.Equal(expectedAccountName, actualAccountOutput.AccountName);
			Assert.Equal(expectedBalance, actualAccountOutput.AccountBalance);
	    }

    }
}
