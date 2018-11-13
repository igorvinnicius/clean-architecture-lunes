﻿using System;
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

	    [Fact]
	    public void ShouldHaveABalanceOfZeroWhenMakingATransferOf200AndCurrentBalanceIs200()
	    {
		    var expectedBalance = 0;

			var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", 200);

			sut.MakeTransfer("New Transfer", 200, Guid.NewGuid());

			Assert.Equal(expectedBalance, sut.GetCurrentBalance());
	    }

	    [Fact]
	    public void ShouldHaveABalanceOfMinus100WhenMakingATransferOf300AndCurrentBalanceIs200()
	    {
		    var sut = new Account("Sut Account");

		    sut.AddRevenue("Revenue", 200);

			sut.MakeTransfer("New Transfer", 300, Guid.NewGuid());

			Assert.Equal(-100, sut.GetCurrentBalance());
	    }

		[Fact]
		public void AccountShouldKeepAllExpenses()
		{
			var sut = new Account("Sut Account");

			sut.AddExpense("Transefer", 600);
			sut.AddExpense("Transfer 2", 200);

			var transfers = sut.GetExpenses();

			Assert.NotEmpty(transfers);
			Assert.Equal(2, transfers.Count);
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
