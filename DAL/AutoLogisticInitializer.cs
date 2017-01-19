using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AutoLogistic.Models;

namespace AutoLogistic.DAL
{
    public class AutoLogisticInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AutoLogisticContext>
    {
        protected override void Seed(AutoLogisticContext context)
        {
            var city1 = new City();
            city1.Name = "Nis" ;
            var city2 = new City();
            city2.Name = "Leskovac";
            var city3 = new City();
            city3.Name = "Krusevac";
            var city4 = new City();
            city4.Name = "Smederevo";

            var Cities = new List<City>();
            Cities.Add(city1);
            Cities.Add(city2);
            Cities.Add(city3);
            Cities.Add(city4);

            Cities.ForEach(s => context.City.Add(s));
            context.SaveChanges();

            var Transporters = new List<Transporter>
            {
            new Transporter{TransporterId=1,Name="Nikola"},
            new Transporter{TransporterId=2,Name="Goran"},
            new Transporter{TransporterId=3,Name="Slavoljub"},
            new Transporter{TransporterId=4,Name="Mica"}
            };

            Transporters.ForEach(s => context.Transporter.Add(s));
            context.SaveChanges();

            var route1 = new Route();
            route1.TransporterId = 1;
            route1.Name = "Prva";

            var route2 = new Route();
            route2.TransporterId = 2;
            route2.Name = "Druga";

            var route3 = new Route();
            route3.TransporterId = 2;
            route3.Name = "Treca";

            route1.Cities.Add(city1);
            route1.Cities.Add(city3);

            route2.Cities.Add(city4);
            route2.Cities.Add(city3);
            route2.Cities.Add(city1);

            route3.Cities.Add(city3);
            route3.Cities.Add(city1);

            var Routes = new List<Route>();
            Routes.Add(route1);
            Routes.Add(route2);
            Routes.Add(route3);

            Routes.ForEach(s => context.Route.Add(s));
            context.SaveChanges();

        }
    }
}