using System;
using lunes.Domain.Accounts;

namespace lunes.Common.Tests.Builders
{
    public class AccountBuilder
    {
	    public static Guid DefaultId = Guid.NewGuid();

	    public static string DefaultName = "New Account";

	    public static double DefaultBalance = 0;

	    private Guid _id;

	    private string _name;

	    private double _balance;

		public AccountBuilder()
		{
			this._id = DefaultId;
			this._name = DefaultName;
			this._balance = DefaultBalance;
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

	    public AccountBuilder WithBalance(double balance)
	    {
		    this._balance = balance;
		    return this;
	    }

	    public Account Build(double initialBalance = 0)
	    {
			var account = new Account(_name);

			if(initialBalance > 0)
				account.AddRevenue("Inital Balance", initialBalance);

		    return account;
	    }

    }
}
