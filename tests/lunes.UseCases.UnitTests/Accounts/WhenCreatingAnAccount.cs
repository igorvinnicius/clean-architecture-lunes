using System.Threading.Tasks;
using lunes.Domain.Accounts;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.CreateAccount;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class WhenCreatingAnAccount
    {
	    [Fact]
	    public async Task ShouldHasANameAndBalanceZero()
	    {
		    var accountRepository = new Mock<IAccountRepository>();

		    var expectedAccountName = "Use Case Account";
		    double expectedBalance = 0;

		    var sut = new CreateAccountUseCase(accountRepository.Object);

		    var actualAccountOutput = await sut.Run(expectedAccountName);

			Assert.Equal(expectedAccountName, actualAccountOutput.AccountName);
			Assert.Equal(expectedBalance, actualAccountOutput.AccountBalance);

			accountRepository.Verify(x => x.Add(It.IsAny<Account>()));
	    }

    }
}
