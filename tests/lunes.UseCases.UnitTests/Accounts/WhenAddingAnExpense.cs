using System;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.AddExpense;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
	public class WhenAddingAnExpense : AccountUseCasesTestBase
    {
	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountReadOnlyRepository;
	    private readonly Mock<IAccountWriteOnlyRepository> _mockAccountRepository;

	    private Guid _accountId;
	    private readonly Account _account;

	    private readonly IAddExpenseUseCase _sut;

	    public WhenAddingAnExpense()
	    {
		    _account = CreateAccount("New Account", 400);

		    _mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
		    _mockAccountRepository = new Mock<IAccountWriteOnlyRepository>();

			_sut = new AddExpenseUseCase(_mockAccountReadOnlyRepository.Object, _mockAccountRepository.Object);

		}

		[Fact]
	    public async void ShouldCalculateTheCorrectBalance()
	    {
		    AssumeAccountInRepository();

		    var expectedBalance = 200;

		    var addExpenseOutput = await _sut.Run(_accountId,"New Expense", 200);

		    Assert.Equal(expectedBalance, addExpenseOutput.Balance);

		}

	    [Fact]
	    public async void ShouldCallUpdateInRepositoryProperly()
	    {
		    AssumeAccountInRepository();

		    await _sut.Run(_account.Id, "New Expense",100);

		    _mockAccountRepository.Verify(x => x.Update(It.IsAny<Account>()));
	    }

		private void AssumeAccountInRepository()
	    {
		    _accountId = _account.Id;

		    _mockAccountReadOnlyRepository.Setup(x => x.GetAccount(_accountId)).ReturnsAsync(_account);

	    }

	}
}
