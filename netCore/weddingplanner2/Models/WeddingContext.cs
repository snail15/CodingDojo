using Microsoft.EntityFrameworkCore;
using weddingplanner2.Models;

namespace weddingplanner2.Models
{
    public class WeddingContext : DbContext {
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options){ }

        public DbSet<User> Users {get; set;}
        public DbSet<Wedding> Weddings {get; set;}
        public DbSet<Rsvp> Rsvps {get; set;}
    }
}