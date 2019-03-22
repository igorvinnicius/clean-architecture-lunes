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
	    private readonly Mock<IAccountWriteOnlyRepository> _mockAccountRepository;
		
	    public WhenCreatingAnAccount()
	    {
		    _mockAccountRepository = new Mock<IAccountWriteOnlyRepository>();
	    }

	    [Fact]
	    public async Task ShouldHasANameAndBalanceZero()
	    {
			var expectedAccountName = "Use Case Account";
		    decimal expectedBalance = 0;

		    var sut = new CreateAccountUseCase(_mockAccountRepository.Object);

		    var actualAccountOutput = await sut.Run(expectedAccountName);

			Assert.Equal(expectedAccountName, actualAccountOutput.AccountName);
			Assert.Equal(expectedBalance, actualAccountOutput.AccountBalance);
			
	    }

	    [Fact]
	    public async Task ShouldCallAddMethodInRepositoryProperly()
	    {
			var sut = new CreateAccountUseCase(_mockAccountRepository.Object);

			await sut.Run("Account");

		    _mockAccountRepository.Verify(x => x.Add(It.IsAny<Account>()));

		}

    }
}
