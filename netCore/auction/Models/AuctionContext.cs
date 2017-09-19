using Microsoft.EntityFrameworkCore;
namespace auction.Models
{
    public class AuctionContext : DbContext {
        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options) { }

        public DbSet<User> Users {get; set;}
        public DbSet<Auction> Auctions {get; set;}
    }
}