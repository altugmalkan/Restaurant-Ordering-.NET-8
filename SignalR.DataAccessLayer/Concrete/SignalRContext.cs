using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Concrete;

public class SignalRContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;" +
                                 "Database=SignalRDb;" +
                                 "Username=postgres;" +
                                 "Password=4Lt0g");
    }
    
    public DbSet<About> Abouts { get; set; }
    
    public DbSet<Booking> Bookings { get; set; }
    
    public DbSet<Carousel> Carousels { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Contact> Contacts { get; set; }
    
    public DbSet<Discount> Discounts { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<SocialMedia> SocialMedias { get; set; }
    
    public DbSet<Testimonial> Testimonials { get; set; }
    
}