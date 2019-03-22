using System;
using lunes.Common.Tests.Builders;
using lunes.Domain.Accounts;

namespace lunes.UseCases.UnitTests.Accounts
{
    public class AccountUseCasesTestBase
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
