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

		    var accountId = Guid.Parse("34601486-c3d6-4ecb-9305-bd4853c26e97");

		    var expectedBalance = 200;

		    var sut = new AddRevenueUseCase(_mockAccountReadOnlyRepository.Object, _mockAccountRepository.Object);

		    var addRevenueOutput =  await sut.Run(accountId, expectedBalance);

			Assert.Equal(expectedBalance, addRevenueOutput.Balance);

	    }

	    private void AssumeAccountInRepository()
	    {
		    _account = new Account("New Account");

		    _mockAccountReadOnlyRepository.Setup(x => x.GetAccount(It.IsAny<Guid>())).ReturnsAsync(_account);

	    }

	}
}
