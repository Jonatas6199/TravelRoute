using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRoutePersistence.Model;

namespace TravelRoutePersistence.DatabaseContext
{
    public class TravelRouteContext : DbContext
    {
        public TravelRouteContext(DbContextOptions<TravelRouteContext> options) : base(options)
        {

        }
        public DbSet<Route> TravelRoutes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>().ToTable("Route");
        }
    }
}
