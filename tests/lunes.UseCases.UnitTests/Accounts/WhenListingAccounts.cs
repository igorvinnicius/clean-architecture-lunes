using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.ListAccounts;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class WhenListingAccounts : AccountUseCasesTestBase
    {
	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountRepository;

	    private List<Account> _accountsToAssume;

	    private readonly ListAccountsUseCase _sut;

	    public WhenListingAccounts()
	    {
		    _mockAccountRepository = new Mock<IAccountReadOnlyRepository>();
			_sut = new ListAccountsUseCase(_mockAccountRepository.Object);
	    }

		[Fact]
	    public async Task ShouldReturnAccountsCorrectly()
	    {
			AssumeAccountInRepository();
			
			var listAccountsOutput = await _sut.Run();

			Assert.Equal(_accountsToAssume.Count, listAccountsOutput.Accounts.Count());
			Assert.True(_accountsToAssume.SequenceEqual(listAccountsOutput.Accounts.ToList()));
	    }

	    private void AssumeAccountInRepository()
	    {
		    var account1 = CreateAccount("Account 1");

			var account2 = CreateAccount("Account 2");

			_accountsToAssume = new List<Account>(){account1, account2};

			_mockAccountRepository.Setup(x => x.GetAllAccounts()).ReturnsAsync(_accountsToAssume);

	    }
	}
}
