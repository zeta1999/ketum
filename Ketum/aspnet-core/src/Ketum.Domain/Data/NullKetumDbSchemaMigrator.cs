using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ketum.Data
{
    /* This is used if database provider does't define
     * IketumDbSchemaMigrator implementation.
     */
    public class NullketumDbSchemaMigrator : IketumDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}