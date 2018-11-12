using System;
using lunes.Common.Tests.Builders;
using lunes.Domain.Accounts;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenMakingATransfer
    {
	    [Fact]
	    public void ShouldHaveABalanceOf100WhenMakingATransferOf100AndCurrentBalanceIs200()
	    {
		    var expectedBalance = 100;

		    var sut = CreateAccount("From Account");

			sut.AddRevenue("Revenue", 200);

		    sut.MakeTransfer("New Transfer", 100, Guid.NewGuid());

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
