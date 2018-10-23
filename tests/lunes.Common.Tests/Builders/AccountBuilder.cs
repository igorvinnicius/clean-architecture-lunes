using System;

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

		public AccountBuilder(Guid id, string name, double balance)
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

    }
}
