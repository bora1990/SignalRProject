using Microsoft.EntityFrameworkCore;
using SignalRAPI.Entities;

namespace SignalRAPI.DAL
{
    public class SignalRContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-L5FHJU6;Initial Catalog=SignalRDb;integrated Security=True;");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
