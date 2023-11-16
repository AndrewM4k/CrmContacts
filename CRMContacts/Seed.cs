using CRMContacts.Models;
using CRMContacts.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CRMContacts
{
    public static class Seed
    {
        public static async Task SeedDataContext(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ContactsDbContext>();

                if (!await context.Contacts.AnyAsync())
                {
                    var contacts = new List<Contact>()
                    {
                        new() {
                            Name = "Admin",
                            MobilePhone = "+375447270845",
                            JobTitle = "Developer",
                            BirthDate = DateTime.Now,
                        },
                    };
                    await context.Contacts.AddRangeAsync(contacts);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
