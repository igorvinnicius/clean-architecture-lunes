using System;
using lunes.Common.Tests.Builders;
using lunes.Domain.Accounts;

namespace lunes.Domain.UnitTests.Accounts
{
    public class AccountDomainTestBase
    {
	    protected Account CreateAccount(string name, decimal initialBalance = 0)
	    {
		    return new AccountBuilder()
			    .WithId(Guid.NewGuid())
			    .WithName(name)
			    .WithInitialBalance(initialBalance)
			    .Build();
	    }
	}
}
