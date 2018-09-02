using System;

namespace lunes.Domain.Entities
{
    public class Account
    {
	    public Guid Id { get; }
	    public string Name { get; private set; }
	    public double Balance { get; private set; }
    }
}
