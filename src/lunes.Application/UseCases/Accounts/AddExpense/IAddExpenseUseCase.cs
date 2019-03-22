using System;
using System.Threading.Tasks;

namespace lunes.Application.UseCases.Accounts.AddExpense
{
    public interface IAddExpenseUseCase
    {
	    Task<AddExpenseOutput> Run(Guid accountId, string name, decimal value);

    }
}
