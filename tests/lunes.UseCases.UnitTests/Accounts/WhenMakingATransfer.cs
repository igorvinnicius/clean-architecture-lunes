using System;
using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.MakeTransfer;
using lunes.Common.Tests.Builders;
using lunes.Domain.Accounts;
using Moq;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
	public class WhenMakingATransfer : AccountUseCasesTestBase
    {

	    private readonly Mock<IAccountReadOnlyRepository> _mockAccountReadOnlyRepository;
	    private readonly Mock<IAccountWriteOnlyRepository> _mockAccountRepository;

	    private Guid _fromAccountId;
	    private readonly Account _fromAccount;

	    private Guid _toAccountId;
	    private readonly Account _toAccount;

		private readonly IMakeTransferUseCase _sut;

	    public WhenMakingATransfer()
	    {
		    _fromAccount = CreateAccount("FromAccount");
		    _toAccount = CreateAccount("ToAccount");

			_mockAccountReadOnlyRepository = new Mock<IAccountReadOnlyRepository>();
		    _mockAccountRepository = new Mock<IAccountWriteOnlyRepository>();

		    _sut = new MakeTransferUseCase(_mockAccountReadOnlyRepository.Object, _mockAccountRepository.Object);
	    }

		[Fact]
	    public async void ShouldDebitAmountInFromAccountCorrectly()
	    {
		    AssumeAccountInRepository();

			_fromAccount.AddRevenue("Initial Balance", 200);

		    var makeTransferOutput = await _sut.Run("New Transfer", 100, _fromAccountId, _toAccountId);

		    var expectedBalance = 100;

			Assert.Equal(expectedBalance, makeTransferOutput.FromAccountBalance);

		}

	    [Fact]
	    public async void ShouldCreditAmountInToAccountCorrectly()
	    {
		    AssumeAccountInRepository();

		    var makeTransferOutput = await _sut.Run("New Transfer", 100, _fromAccountId, _toAccountId);

		    var expectedBalance = 100;

		    Assert.Equal(expectedBalance, makeTransferOutput.ToAccountBalance);

	    }

	    [Theory]
		[InlineData(100, 100, 100, 0, 200)]
	    [InlineData(100, -100, 100, 0, 0)]
	    [InlineData(-100, 100, 100, -200, 200)]
	    //[InlineData(125.74, 0, 100, 25.74, 100)]
		public async void ShouldDebitInFromAccountAndCreditAmountInToAccountCorrectly(double fromAccountInitialBalance, double toAccountInitalBalance, double amount, double expectedFromAccountBalance, double expectedToAccountBalance)
	    {
		    AssumeAccountInRepository();

		    _fromAccount.AddRevenue("Initial Balance", fromAccountInitialBalance);

		    _toAccount.AddRevenue("Initial Balance", toAccountInitalBalance);

			var makeTransferOutput = await _sut.Run("New Transfer", amount, _fromAccountId, _toAccountId);

			Assert.Equal(expectedFromAccountBalance, makeTransferOutput.FromAccountBalance);
			Assert.Equal(expectedToAccountBalance, makeTransferOutput.ToAccountBalance);
	    }

		[Fact]
		public async void ShouldCallUpdateinRepositoryProperly()
		{
			AssumeAccountInRepository();

			await _sut.Run("New Transfer", 100, _fromAccountId, _toAccountId);

			_mockAccountRepository.Verify(x => x.Update(It.IsAny<Account>()));
		}

		private void AssumeAccountInRepository()
	    {
		    _fromAccountId = _fromAccount.Id;
		    _toAccountId = _toAccount.Id;

			_mockAccountReadOnlyRepository.Setup(x => x.GetAccount(_fromAccountId)).ReturnsAsync(_fromAccount);
			_mockAccountReadOnlyRepository.Setup(x => x.GetAccount(_toAccountId)).ReturnsAsync(_toAccount);

	    }

	}
}
