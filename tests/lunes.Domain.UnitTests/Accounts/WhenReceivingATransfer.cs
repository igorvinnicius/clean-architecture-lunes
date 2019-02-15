using System;
using lunes.Common.Tests.Builders;
using lunes.Domain.Accounts;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenReceivingATransfer
    {
	    [Fact]
	    public void ShouldHaveABalanceOf100WhenReceivingATransferOf100AndCurrentBalanceIs0()
	    {
		    var expectedBalance = 100;

		    var sut = CreateAccount("From Account");

		    sut.ReceiveTransfer("New Transfer", 100, Guid.NewGuid());

		    Assert.Equal(expectedBalance, sut.GetCurrentBalance());

	    }

	    [Theory]
		[InlineData(100, 100, 200)]
	    [InlineData(1055.30, 300, 1355.30)]
	    [InlineData(-220, 100, -120)]
	    [InlineData(-300, 500, 200)]
		public void ShouldCalculateBalanceCorrectly(double intitalBalance, double amount, double expectedBalance)
	    {
		    var sut = CreateAccount("From Account");

		    sut.AddRevenue("New Transfer", intitalBalance);

			sut.ReceiveTransfer("New Transfer", amount, Guid.NewGuid());

		    Assert.Equal(expectedBalance, sut.GetCurrentBalance());

	    }

		private Account CreateAccount(string name)
	    {
		    return new AccountBuilder()
			    .WithId(Guid.NewGuid())
			    .WithName(name)
			    .Build();
	    }
	}
}
