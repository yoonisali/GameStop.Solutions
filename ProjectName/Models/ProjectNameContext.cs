// Needed for accessing database

using Microsoft.EntityFrameworkCore;


namespace $ProjectName.Models 
{
  public class $ProjectNameContext : DbContext 
  {
    public DbSet<ClassName> ClassNames { get; set; }  // CHANGE CLASS NAME!!!

    public $ProjectNameContext(DbContextOptions options) : base(options) { } 
  }
}