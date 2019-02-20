using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.UpdateAccount;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class WhenUpdatingAnAccount : AccountUseCasesTestBase
    {
	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountReadOnlyRepository;
	    private readonly Mock<IAccountWriteOnlyRepository> _mockAccountRepository;

	    private Account _account;
	    private UpdateAccountUseCase _sut;

		public WhenUpdatingAnAccount()
	    {
			_mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
			_mockAccountRepository = new Mock<IAccountWriteOnlyRepository>();

			_sut = new UpdateAccountUseCase(_mockAccountReadOnlyRepository.Object, _mockAccountRepository.Object);
		}

	    [Fact]
	    public async  Task ShouldUpdateAccountNameProperly()
		{
			AssumeAccountInRepository();

			var expectedAccountName = "Updated Account";

			var actualAccountOutput = await _sut.Run(_account.Id, expectedAccountName);

			Assert.Equal(expectedAccountName, actualAccountOutput.AccountName);
		}

		[Fact]
	    public async Task ShouldCallUpdateinRepositoryProperly()
	    {
			AssumeAccountInRepository();

		    await _sut.Run(_account.Id, "Updated Account");

			_mockAccountRepository.Verify(x => x.Update(It.IsAny<Account>()));
		}

	    private void AssumeAccountInRepository()
	    {
		    _account = CreateAccount("New Account");

		    _mockAccountReadOnlyRepository.Setup(x => x.GetAccount(It.IsAny<Guid>())).ReturnsAsync(_account);

	    }

	}
}
