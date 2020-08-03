using ketum.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ketum.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ketumEntityFrameworkCoreDbMigrationsModule),
        typeof(ketumApplicationContractsModule)
        )]
    public class ketumDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
