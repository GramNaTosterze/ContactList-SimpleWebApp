using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContactList_SimpleWebApp.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ContactList_SimpleWebApp.Data
{
    public class ContactList_SimpleWebAppContext : IdentityDbContext
    {
        public ContactList_SimpleWebAppContext(DbContextOptions<ContactList_SimpleWebAppContext> options)
            : base(options)
        {
        }
        public DbSet<ContactList_SimpleWebApp.Models.ContactCategory> Categories { get; set; } = default!;
        public DbSet<ContactList_SimpleWebApp.Models.Contact> Contact { get; set; } = default!;
    }
}
