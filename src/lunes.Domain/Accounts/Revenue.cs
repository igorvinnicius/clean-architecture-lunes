using System;
using System.Threading;

namespace lunes.Domain.Accounts
{
	public class Revenue : Operation
	{
		public Revenue() {}

		public Revenue(Guid accountId, string name, decimal amount) 
			: base(accountId, name, amount)
		{
			OperationNature = OperationNature.Credit;
		}
	}
}
