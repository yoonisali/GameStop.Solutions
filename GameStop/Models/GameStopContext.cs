using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace GameStop.Models 
{
  public class GameStopContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Gamer> Gamers { get; set; } 
    public DbSet<VideoGame> VideoGames { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<VideoGameTag> VideoGameTags { get; set; }

    public GameStopContext(DbContextOptions options) : base(options) { } 
  }
}