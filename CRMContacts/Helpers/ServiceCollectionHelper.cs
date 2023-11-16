using Microsoft.EntityFrameworkCore;

namespace CRMContacts.Helpers
{
    public static class ServiceCollectionHelper
    {
        public static async Task ApplyMigrationForDbContext<T>(this IServiceProvider services) where T : DbContext
        {
            using var scope = services.CreateScope();
            var context = scope.ServiceProvider.GetService<T>();
            await DbContextHelper.ApplyMigrations(context);
        }
    }
}
