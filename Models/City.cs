using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoLogistic.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Route> Routes { get; set; }

        public City() {
            Routes = new HashSet<Route>();
        }
    }
}