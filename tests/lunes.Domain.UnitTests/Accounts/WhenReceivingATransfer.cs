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

	    private Account CreateAccount(string name)
	    {
		    return new AccountBuilder()
			    .WithId(Guid.NewGuid())
			    .WithName(name)
			    .Build();
	    }
	}
}
