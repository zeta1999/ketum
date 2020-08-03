using ketum.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ketum
{
    [DependsOn(
        typeof(ketumEntityFrameworkCoreTestModule)
        )]
    public class ketumDomainTestModule : AbpModule
    {

    }
}