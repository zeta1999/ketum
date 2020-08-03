using System.Threading.Tasks;

namespace ketum.Data
{
    public interface IketumDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
