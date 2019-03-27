using lunes.Application.Repositories.Accounts;
using lunes.Persistence.EntityFrameworkDataAccessAdapter;
using lunes.Persistence.EntityFrameworkDataAccessAdapter.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace lunes.Infrastructure.DependencyInjection.Installers
{
    public static class EntityFrameworkRepositoriesInstaller
    {
	    public static void Install(IServiceCollection serviceCollection)
	    {
		    serviceCollection.AddSingleton<IContext, Context>();

		    serviceCollection.AddTransient<IAccountReadOnlyRepository, AccountRepository>();
		    serviceCollection.AddTransient<IAccountWriteOnlyRepository, AccountRepository>();
	    }
	}
}
