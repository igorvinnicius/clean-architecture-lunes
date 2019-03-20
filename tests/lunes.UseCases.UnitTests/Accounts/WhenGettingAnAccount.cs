using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.GetAccount;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class WhenGettingAnAccount : AccountUseCasesTestBase
	{
	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountRepository;

	    private List<Account> _accountsToAssume;

	    private IGetAccountUseCase _sut;

		public WhenGettingAnAccount()
	    {
		    _mockAccountRepository = new Mock<IAccountReadOnlyRepository>();
			_sut = new GetAccountUseCase(_mockAccountRepository.Object);
	    }

		[Fact]
	    public async Task ShouldReturnAnAccountCorrectly()
	    {
			AssumeAccountInRepository();

			var accountId = _accountsToAssume.First().Id;

			var output = await _sut.Run(accountId);

			Assert.NotNull(output.Account);
			Assert.Equal(accountId, output.Account.Id);

	    }

	    private void AssumeAccountInRepository()
	    {
		    var account1 = CreateAccount("Account 1");

		    _accountsToAssume = new List<Account>() { account1 };

		    _mockAccountRepository.Setup(x => x.GetAccount(It.Is<Guid>(y => y.Equals(account1.Id)))).ReturnsAsync(account1);

	    }
	}
}
