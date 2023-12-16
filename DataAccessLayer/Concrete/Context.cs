using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OK3QKVJ;Database=Dingo;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=True;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}
