using System;
using lunes.Domain.Accounts;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenCreatingARevenue
    {
	    [Fact]
	    public void ShouldInitializeCorretly()
	    {
		    var expectedName = "Name";
		    var expectedAmount = 100;
		    var expectedDate = DateTime.Now;

		    var sut = new Revenue(Guid.NewGuid(), expectedName, expectedAmount);

		    Assert.Equal(expectedName, sut.Name);
		    Assert.Equal(expectedAmount, sut.Amount);
		    Assert.Equal(expectedDate.Date, sut.Date.Date);

	    }
	}
}
