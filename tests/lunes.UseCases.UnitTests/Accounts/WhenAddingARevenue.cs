using System;
using System.Threading.Tasks;
using lunes.Application.UseCases.Accounts.AddRevenue;
using lunes.Domain.Accounts;
using Xunit;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class WhenAddingARevenue
    {

	    [Fact]
	    public async Task ShouldAndReturnTheCorrecBalance()
	    {
			//34601486-c3d6-4ecb-9305-bd4853c26e97

		    var expectedBalance = 200;

		    var account = new Account("New Account");

		    var sut = new AddRevenueUseCase();

		    var addRevenueOutput =  await sut.Run(expectedBalance);

			Assert.Equal(expectedBalance, addRevenueOutput.Balance);

	    }

    }
}
