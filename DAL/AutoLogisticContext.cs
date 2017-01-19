using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AutoLogistic.Models;

namespace AutoLogistic.DAL
{
    public class AutoLogisticContext : DbContext
    {

        public AutoLogisticContext() : base("AutoLogisticContext")
        {
        }

        public DbSet<City> City { get; set; }
        public DbSet<Route> Route { get; set; }
        public DbSet<Transporter> Transporter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>().
                   HasMany(d => d.Cities).
                   WithMany(e=> e.Routes).
                   Map(
                        m =>
                        {
                            m.MapLeftKey("RouteId");
                            m.MapRightKey("CityId");
                            m.ToTable("RouteCity");
                        });
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}