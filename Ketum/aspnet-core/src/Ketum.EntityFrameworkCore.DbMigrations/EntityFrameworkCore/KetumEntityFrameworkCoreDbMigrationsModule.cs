using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace ketum.EntityFrameworkCore
{
    [DependsOn(
        typeof(ketumEntityFrameworkCoreModule)
        )]
    public class ketumEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<ketumMigrationsDbContext>();
        }
    }
}
