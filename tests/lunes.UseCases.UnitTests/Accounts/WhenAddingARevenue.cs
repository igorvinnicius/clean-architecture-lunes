using System;
using System.Threading.Tasks;
using lunes.Application.Exceptions;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.AddRevenue;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class WhenAddingARevenue : AccountUseCasesTestBase
    {
	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountReadOnlyRepository;
	    private readonly Mock<IAccountWriteOnlyRepository> _mockAccountRepository;

	    private Guid _accountId;
	    private Account _account;

	    private IAddRevenueUseCase _sut;

		public WhenAddingARevenue()
	    {
			_mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
		    _mockAccountRepository = new Mock<IAccountWriteOnlyRepository>();

			_sut = new AddRevenueUseCase(_mockAccountReadOnlyRepository.Object, _mockAccountRepository.Object);
		}

		[Fact]
	    public async Task ShouldAndReturnTheCorrecBalance()
	    {
			AssumeAccountInRepository();

		    var expectedBalance = 200;

		    var addRevenueOutput =  await _sut.Run(_accountId, "New Revenue", expectedBalance);

			Assert.Equal(expectedBalance, addRevenueOutput.Balance);

	    }

	    [Fact]
	    public async Task ShouldThrowAccountNotFoundExceptionWhenAccountIsNotFound()
	    {
		    await Assert.ThrowsAsync<AccountNotFoundException>(async () =>
		    {
			    AssumeAccountInRepository();

			    await _sut.Run(Guid.NewGuid(), "New Revenue", 100);
		    });
	    }

		[Fact]
	    public async Task ShouldCallUpdateinRepositoryProperly()
	    {
		    AssumeAccountInRepository();

		    await _sut.Run(_account.Id, "New Revenue", 100);

		    _mockAccountRepository.Verify(x => x.Update(It.IsAny<Account>()));
	    }

		private void AssumeAccountInRepository()
	    {
		    _account =  CreateAccount("New Account");

			_accountId = _account.Id;

		    _mockAccountReadOnlyRepository.Setup(x => x.GetAccount(_accountId)).ReturnsAsync(_account);

	    }

	}
}
