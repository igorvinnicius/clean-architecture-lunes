using System;
using lunes.Domain.Accounts;

namespace lunes.Common.Tests.Builders
{
    public class AccountBuilder
    {
	    public static Guid DefaultId = Guid.NewGuid();

	    public static string DefaultName = "New Account";

	    public static decimal DefaultInitialBalance = 0;

	    private Guid _id;

	    private string _name;

	    private decimal _initialBalance;

		public AccountBuilder()
		{
			this._id = DefaultId;
			this._name = DefaultName;
			this._initialBalance = DefaultInitialBalance;
		}

		public AccountBuilder WithId(Guid id)
	    {
		    this._id = id;
		    return this;
	    }

	    public AccountBuilder WithName(string name)
	    {
		    this._name = name;
		    return this;
	    }

	    public AccountBuilder WithInitialBalance(decimal balance)
	    {
		    this._initialBalance = balance;
		    return this;
	    }

	    public Account Build()
	    {
			var account = new Account(_name);

			if(_initialBalance > 0)
				account.AddRevenue("Initial Balance", _initialBalance);
			
			if (_initialBalance < 0)
				account.AddExpense("Initial Balance", Math.Abs(_initialBalance));

			return account;
	    }

    }
}
