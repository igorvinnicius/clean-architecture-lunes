using System;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.AddExpense;
using lunes.Application.UseCases.Accounts.MakeTransfer;
using lunes.Common.Tests.Builders;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class WhenMakingATransfer
    {

	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountReadOnlyRepository;
	    private readonly Mock<IAccountRepository> _mockAccountRepository;

	    private Guid _accountId;
	    private readonly Account _account;

	    private readonly MakeTransferUseCase _sut;

	    public WhenMakingATransfer()
	    {
		    _account = new AccountBuilder().Build();
		    _account.AddRevenue("Initial Balance", 200);

		    _mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
		    _mockAccountRepository = new Mock<IAccountRepository>();

		    _sut = new MakeTransferUseCase(_mockAccountReadOnlyRepository.Object, _mockAccountRepository.Object);

	    }

		[Fact]
	    public async void ShouldCalculateTheCorrectBalance()
	    {
		    AssumeAccountInRepository();

		    var expectedBalance = 200;

		    var makeTransferOutput = await _sut.Run("New Transfer", 100, _accountId, Guid.NewGuid());

		    Assert.Equal(expectedBalance, makeTransferOutput.Balance);

		}


	    [Fact]
	    public async void ShouldCallUpdateinRepositoryProperly()
	    {
		    AssumeAccountInRepository();

			await _sut.Run("New Transfer", 100, _accountId, Guid.NewGuid());

			_mockAccountRepository.Verify(x => x.Update(It.IsAny<Account>()));
	    }

		private void AssumeAccountInRepository()
	    {
		    _accountId = _account.Id;

		    _mockAccountReadOnlyRepository.Setup(x => x.GetAccount(_accountId)).ReturnsAsync(_account);

	    }

	}
}
