using Autofac;
using ZepteritTask.Repository.Interfaces;

namespace ZepteritTask.Repository
{
    public static class IoC
    {
        public static void RegisterRepositories(this ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IOrderRepository).Assembly)
                .Where(w => w.Name.Contains("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
