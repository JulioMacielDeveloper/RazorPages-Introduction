using Microsoft.EntityFrameworkCore;
using RazorPagesIntroduction.Models;

namespace RazorPagesIntroduction.Pages.Data
{
    public class ContactsContext : DbContext
    {
    
        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
    }

    
}