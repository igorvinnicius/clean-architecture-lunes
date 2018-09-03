﻿using lunes.Domain.Entities;
using Xunit;

namespace lunes.Domain.UnitTests.Accounts
{
    public class WhenAddingARevenue
    {
	    [Fact]
	    public void ShouldHaveABalanceOf100WhenAddingARevenueOf100AndCurrentBalanceIsZero()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue(100);

			Assert.Equal(100, sut.Balance);
	    }


    }
}