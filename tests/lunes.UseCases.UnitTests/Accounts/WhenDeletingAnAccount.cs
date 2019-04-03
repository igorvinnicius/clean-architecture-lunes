using System;
using System.Threading.Tasks;
using lunes.Application.Exceptions;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.DeleteAccount;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class WhenDeletingAnAccount : AccountUseCasesTestBase
    {
	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountReadOnlyRepository;
	    private readonly Mock<IAccountWriteOnlyRepository> _mockAccountRepository;

	    private Account _account;
	    private IDeleteAccountUseCase _sut;

	    public WhenDeletingAnAccount()
	    {
		    _mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
		    _mockAccountRepository = new Mock<IAccountWriteOnlyRepository>();

		    _sut = new DeleteAccountUseCase(_mockAccountReadOnlyRepository.Object, _mockAccountRepository.Object);
	    }

		[Fact]
	    public async Task ShouldDeleteAccountCorrectly()
	    {
			AssumeAccountInRepository();

		    var accountId = _account.Id;

		    var output = await _sut.Run(accountId);

			Assert.True(output.AccountDeleted);
	    }

		[Fact]
		public async Task ShouldThrowAccountNotFoundExceptionWhenAccountIsNotFound()
		{
			await Assert.ThrowsAsync<AccountNotFoundException>(async () =>
			{
				await _sut.Run(Guid.NewGuid());
			});
		}

		private void AssumeAccountInRepository()
	    {
		    _account = CreateAccount("New Account");

		    _mockAccountReadOnlyRepository.Setup(x => x.GetAccount(It.IsAny<Guid>())).ReturnsAsync(_account);

	    }

	}
}
