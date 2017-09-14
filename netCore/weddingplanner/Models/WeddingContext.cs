using Microsoft.EntityFrameworkCore;
using weddingplanner.Models;

namespace weddingplanner.Models
{
    public class WeddingContext : DbContext {
        public WeddingContext(DbContextOptions<WeddingContext> options) : base(options){ }

        public DbSet<User> Users {get; set;}
        public DbSet<Wedding> Weddings {get; set;}
        public DbSet<Rsvp> Revps {get; set;}
    }
}