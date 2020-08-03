using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace ketum.EntityFrameworkCore
{
    public static class ketumDbContextModelCreatingExtensions
    {
        public static void Configureketum(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(ketumConsts.DbTablePrefix + "YourEntities", ketumConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}