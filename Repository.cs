using AutoLogistic.DAL;
using AutoLogistic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoLogistic
{
    public static class Repository
    {
        public static RoutesViewModel GetAllRoutes() {
            using ( var dbContext = new AutoLogisticContext())
            {
                var routes = dbContext.Route.ToList();

                var cities = new Dictionary<Route, string>();
                var transporters = new Dictionary<Route, string>();
                foreach (var route in routes)
                {
                    var result = string.Empty;
                    foreach (var city in dbContext.Route.First(m=> m.RouteId == route.RouteId).Cities)
                    {
                        result += city.Name + " ";
                    }

                    cities.Add(route, result);
                    transporters.Add(route, dbContext.Route.First(m => m.RouteId == route.RouteId).Transporter.Name);
                }

                return new RoutesViewModel()
                {
                    Transporters = transporters,
                    Cities = cities,
                    Routes = routes,
                    Filter = string.Empty,
                    FilterName = string.Empty
                };

            }
        }

        public static RoutesViewModel GetFilteredRoutes(string filterName, string filter)
        {
            using (var dbContext = new AutoLogisticContext())
            {
                List<Route> routes = new List<Route>();
                if (filterName.Equals("Transporter"))
                {
                    routes = dbContext.Route.Where(m => m.Transporter.Name == filter).ToList();
                }
                else if (filterName.Equals("City"))
                {
                    routes = dbContext.Route.Where(m => m.Cities.Any(c=> c.Name == filter)).ToList();
                }
                

                var cities = new Dictionary<Route, string>();
                var transporters = new Dictionary<Route, string>();
                foreach (var route in routes)
                {
                    var result = string.Empty;
                    foreach (var city in dbContext.Route.First(m => m.RouteId == route.RouteId).Cities)
                    {
                        result += city.Name + " ";
                    }

                    cities.Add(route, result);
                    transporters.Add(route, dbContext.Route.First(m => m.RouteId == route.RouteId).Transporter.Name);
                }

                return new RoutesViewModel()
                {
                    Transporters = transporters,
                    Cities = cities,
                    Routes = routes,
                    Filter = string.Empty,
                    FilterName = string.Empty
                };

            }
        }
    }
}