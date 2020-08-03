using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace ketum.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(ketumHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ketumConsoleApiClientModule : AbpModule
    {
        
    }
}
