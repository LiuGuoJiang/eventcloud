using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EventCloud.EntityFrameworkCore
{
    public static class EventCloudDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<EventCloudDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<EventCloudDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
