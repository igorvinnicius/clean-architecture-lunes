using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.UpdateAccount;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class WhenUpdatingAnAccount
    {
	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountRepository;

		[Fact]
	    public async  Task ShouldUpdateAccountNameProperly()
		{
			var expectedAccountName = "Updated Account";

			var account = new Account("New Account");

			var sut = new UpdateAccountUseCase(_mockAccountRepository.Object);

			await sut.Run(account.Id, expectedAccountName);
		}

    }
}
