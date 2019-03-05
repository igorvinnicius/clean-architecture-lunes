using lunes.Application.Repositories.Accounts;
using lunes.Application.UseCases.Accounts.ListAccounts;
using lunes.Infrastructure.InMemoryDataAccessAdapter.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace lunes.Infrastructure.DependencyInjection
{
    public static class Container
    {
	    public static void InstallServicess(IServiceCollection serviceCollection)
	    {
			serviceCollection.AddTransient<IAccountReadOnlyRepository, AccountRepository>();
		    serviceCollection.AddTransient<IAccountWriteOnlyRepository, AccountRepository>();

			serviceCollection.AddScoped<IListAccountsUseCase, ListAccountsUseCase>();
			
	    }
    }
}
