using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoLogistic.Models
{
    public class RoutesViewModel
    {
        public List<Route> Routes { get; set; }
        public Dictionary<Route, string> Cities { get; set; }
        public Dictionary<Route, string> Transporters { get; set; }
        public string Filter { get; set; }
        public string FilterName { get; set; }

        public RoutesViewModel()
        {
            Cities = new Dictionary<Route, string>();
            Transporters = new Dictionary<Route, string>();
            Routes = new List<Route>();
            Filter = string.Empty;
            FilterName = string.Empty;
        }

    }
}