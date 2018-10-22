using System;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.AddRevenue;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class WhenAddingARevenue
    {
	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountReadOnlyRepository;
	    private readonly Mock<IAccountRepository> _mockAccountRepository;

	    private Guid _accountId;
	    private Account _account;

		public WhenAddingARevenue()
	    {
			_mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
		    _mockAccountRepository = new Mock<IAccountRepository>();
		}

		[Fact]
	    public async Task ShouldAndReturnTheCorrecBalance()
	    {
			AssumeAccountInRepository();

		    var expectedBalance = 200;

		    var sut = new AddRevenueUseCase(_mockAccountReadOnlyRepository.Object, _mockAccountRepository.Object);

		    var addRevenueOutput =  await sut.Run(_accountId, expectedBalance);

			Assert.Equal(expectedBalance, addRevenueOutput.Balance);

	    }

	    private void AssumeAccountInRepository()
	    {
		    _account = new Account("New Account");

		    _accountId = _account.Id;

		    _mockAccountReadOnlyRepository.Setup(x => x.GetAccount(_accountId)).ReturnsAsync(_account);

	    }

	}
}
