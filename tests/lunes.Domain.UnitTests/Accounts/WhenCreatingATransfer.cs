using System;
using lunes.Domain.Accounts;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenCreatingATransfer
    {
	    [Fact]
	    public void ShouldInitializeCorrectly()
	    {
		    var expectedName = "New Transfer";
		    var expectedAmount = 100;
		    var expectedDate = DateTime.UtcNow;

		    var expectedFromAccountId = Guid.NewGuid();
		    var expectedToAccountId = Guid.NewGuid();

		    var expectedOperationType = OperationNature.Credit;

		    var sut = new Transfer(expectedName, expectedOperationType, expectedAmount, expectedFromAccountId, expectedToAccountId);

		    Assert.Equal(expectedName, sut.Name);
		    Assert.Equal(expectedAmount, sut.Amount);
		    Assert.Equal(expectedDate.Date, sut.Date.Date);
		    Assert.Equal(expectedFromAccountId, sut.FromAccountId);
		    Assert.Equal(expectedToAccountId, sut.ToAccountId);
		    Assert.Equal(expectedOperationType, sut.OperationNature);
		}
    }
}
