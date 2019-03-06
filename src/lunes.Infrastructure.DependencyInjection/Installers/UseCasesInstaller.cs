using lunes.Application.UseCases.Accounts.ListAccounts;
using Microsoft.Extensions.DependencyInjection;

namespace lunes.Infrastructure.DependencyInjection.Installers
{
    public static class UseCasesInstaller
    {
	    public static void Install(IServiceCollection servicesCollection)
	    {
		    servicesCollection.AddScoped<IListAccountsUseCase, ListAccountsUseCase>();
		}
    }
}
