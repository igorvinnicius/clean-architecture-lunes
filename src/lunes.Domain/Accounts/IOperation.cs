using System;

namespace lunes.Domain.Accounts
{
	public interface IOperation
	{
		string Name { get; }

		DateTime Date { get; }

		decimal Amount { get; }

		OperationNature  OperationNature { get; }
	}
}
