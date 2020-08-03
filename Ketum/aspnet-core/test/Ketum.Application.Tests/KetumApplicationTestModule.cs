using Volo.Abp.Modularity;

namespace ketum
{
    [DependsOn(
        typeof(ketumApplicationModule),
        typeof(ketumDomainTestModule)
        )]
    public class ketumApplicationTestModule : AbpModule
    {

    }
}