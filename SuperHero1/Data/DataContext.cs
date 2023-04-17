using Microsoft.EntityFrameworkCore;

namespace SuperHero1.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options) { }        
        public DbSet<SuperHero1> SuperHeroes { get; set; }      

    }
}
