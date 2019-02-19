using System;
using lunes.Common.Tests.Builders;
using lunes.Domain.Accounts;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenMakingATransfer : AccountDomainTestBase
    {
	    [Fact]
	    public void ShouldHaveABalanceOf100WhenMakingATransferOf100AndCurrentBalanceIs200()
	    {
		    var expectedBalance = 100;

		    var sut = CreateAccount("Sut Account", 200);
			
		    sut.MakeTransfer("New Transfer", 100, Guid.NewGuid());

			Assert.Equal(expectedBalance, sut.GetCurrentBalance());

	    }

	    [Fact]
	    public void ShouldHaveABalanceOfZeroWhenMakingATransferOf200AndCurrentBalanceIs200()
	    {
		    var expectedBalance = 0;

		    var sut = CreateAccount("Sut Account", 200);

			sut.MakeTransfer("New Transfer", 200, Guid.NewGuid());

			Assert.Equal(expectedBalance, sut.GetCurrentBalance());
	    }

	    [Fact]
	    public void ShouldHaveABalanceOfMinus100WhenMakingATransferOf300AndCurrentBalanceIs200()
	    {
			var sut = CreateAccount("Sut Account", 200);

			sut.MakeTransfer("New Transfer", 300, Guid.NewGuid());

			Assert.Equal(-100, sut.GetCurrentBalance());
	    }

    }
}
