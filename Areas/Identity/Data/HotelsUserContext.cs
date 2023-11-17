using Hotels.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Hotels.Models;

namespace Hotels.Data;

public class HotelsUserContext : IdentityDbContext<HotelsUser>
{
    public HotelsUserContext(DbContextOptions<HotelsUserContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<Cart> cart { get; set; }
    public DbSet<Hotel> hotel { get; set; }
    public DbSet<Invoice> invoices { get; set; }
    public DbSet<RoomDetails> roomDetails { get; set; }
    public DbSet<Rooms> rooms { get; set; }
}
