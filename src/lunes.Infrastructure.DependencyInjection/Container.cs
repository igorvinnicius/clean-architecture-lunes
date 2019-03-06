using lunes.Infrastructure.DependencyInjection.Installers;
using Microsoft.Extensions.DependencyInjection;

namespace lunes.Infrastructure.DependencyInjection
{
    public static class Container
    {
	    public static void InstallServices(IServiceCollection servicesCollection)
	    {
			RepositoriesInstaller.Install(servicesCollection);
			UseCasesInstaller.Install(servicesCollection);
	    }
    }
}
