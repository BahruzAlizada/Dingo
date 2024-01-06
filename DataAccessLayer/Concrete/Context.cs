using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-OK3QKVJ;Database=Dingo;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=True;");
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }

    }
}
