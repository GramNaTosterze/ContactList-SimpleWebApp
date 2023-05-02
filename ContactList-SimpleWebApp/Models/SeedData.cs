using ContactList_SimpleWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactList_SimpleWebApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ContactList_SimpleWebAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<ContactList_SimpleWebAppContext>>()))
            {
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new ContactCategory
                        {
                            Category = "Private"
                        },
                        new ContactCategory
                        {
                            Category = "Business"
                        },
                        new ContactCategory
                        {
                            Category = "Other"
                        });

                }
                if (!context.Contact.Any())
                {
                    context.Contact.AddRange(
                    new Contact
                    {
                        Name = "Kamil",
                        Surname = "Ślimak",
                        Email = "kamilślimak@mail.com",
                        Category = "Business",
                        Password = "1234"
                    },
                    new Contact
                    {
                        Name = "Jan",
                        Surname = "Kowalski",
                        Email = "jk@mail.com",
                        Category = "Private",
                        Password = "1234"
                    }); ;
                }
                context.SaveChanges();
            }
        }
    }
}
