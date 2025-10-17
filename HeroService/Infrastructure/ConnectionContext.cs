using BussinessDomains;
using Microsoft.EntityFrameworkCore;

namespace HeroService.Infrastructure
{
    public class ConnectionContext : DbContext
    {


        public ConnectionContext(DbContextOptions<ConnectionContext> options) : base(options)
        {

        }

        public DbSet<Herois> Herois { get; set; }
        public DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }
        public DbSet<Superpoderes> Superpoderes { get; set; }
    }
}
