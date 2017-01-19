using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoLogistic.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        public int TransporterId { get; set; }
        public string Name { get; set; }

        public virtual Transporter Transporter { get; set; }
        public virtual ICollection<City> Cities {get; set; }

        public Route() {
            Cities = new HashSet<City>();
        }

        public string MakeAllCityString()
        {
            var result = string.Empty;
            foreach (var city in Cities)
            {
                result += city + " ";
            }

            return result;
        }
    }
}