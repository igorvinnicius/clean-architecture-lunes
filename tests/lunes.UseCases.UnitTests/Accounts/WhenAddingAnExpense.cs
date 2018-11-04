using System;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.AddExpense;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
	public class WhenAddingAnExpense
    {
	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountReadOnlyRepository;
	    private readonly Mock<IAccountRepository> _mockAccountRepository;

	    private Guid _accountId;
	    private Account _account;

	    private AddExpenseUseCase _sut;

	    public WhenAddingAnExpense()
	    {
			_account = new Account("New Account");
			_account.AddRevenue("Initial Balance", 400);

		    _mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
		    _mockAccountRepository = new Mock<IAccountRepository>();

			_sut = new AddExpenseUseCase(_mockAccountReadOnlyRepository.Object, _mockAccountRepository.Object);

		}

		[Fact]
	    public async void ShouldCalculateTheCorrectBalance()
	    {
		    AssumeAccountInRepository();

		    var expectedBalance = 200;

		    var addExpenseOutput = await _sut.Run(_accountId, 200);

		    Assert.Equal(expectedBalance, addExpenseOutput.Balance);

		}

	    private void AssumeAccountInRepository()
	    {

		    _accountId = _account.Id;

		    _mockAccountReadOnlyRepository.Setup(x => x.GetAccount(_accountId)).ReturnsAsync(_account);

	    }

	}
}
