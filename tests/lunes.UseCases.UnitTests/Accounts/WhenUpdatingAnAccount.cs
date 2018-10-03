using System;
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
	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountReadOnlyRepository;
	    private readonly Mock<IAccountRepository> _mockAccountRepository;

		public WhenUpdatingAnAccount()
	    {
			_mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
			_mockAccountRepository = new Mock<IAccountRepository>();
	    }

	    [Fact]
	    public async  Task ShouldUpdateAccountNameProperly()
		{
			var expectedAccountName = "Updated Account";

			var account = new Account("New Account");

			_mockAccountReadOnlyRepository.Setup(x => x.GetAccount(It.IsAny<Guid>())).ReturnsAsync(account);
			
			var sut = new UpdateAccountUseCase(_mockAccountReadOnlyRepository.Object);

			var actualAccountOutput = await sut.Run(account.Id, expectedAccountName);

			Assert.Equal(expectedAccountName, actualAccountOutput.AccountName);
		}


	    [Fact]
	    public async Task ShouldCallUpdateinRepositoryProperly()
	    {
		    var expectedAccountName = "Updated Account";

		    var account = new Account("New Account");

		    _mockAccountReadOnlyRepository.Setup(x => x.GetAccount(It.IsAny<Guid>())).ReturnsAsync(account);

		    var sut = new UpdateAccountUseCase(_mockAccountReadOnlyRepository.Object);

		    await sut.Run(account.Id, expectedAccountName);

			_mockAccountRepository.Verify(x => x.Update(It.IsAny<Account>()));
		}


	}
}
