using Autofac;
using GM.API.Services;
using GM.Data.Entitis;
using GM.Data.Repositories;

namespace GM.API;

public class DependencyRegister : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Service
        builder.RegisterAssemblyTypes(typeof(ChallengeService).Assembly)
            .Where(x => x.Name.EndsWith("Service"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();

        // Repository
        builder.RegisterAssemblyTypes(typeof(ChallengeRepository).Assembly)
            .Where(x => x.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerLifetimeScope();
    }
}
