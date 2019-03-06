using lunes.Application.Repositories.Accounts;
using lunes.Infrastructure.InMemoryDataAccessAdapter.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace lunes.Infrastructure.DependencyInjection.Installers
{
    public static class RepositoriesInstaller
    {
	    public static void Install(IServiceCollection serviceCollection)
	    {
		    serviceCollection.AddTransient<IAccountReadOnlyRepository, AccountRepository>();
		    serviceCollection.AddTransient<IAccountWriteOnlyRepository, AccountRepository>();
		}
    }
}
