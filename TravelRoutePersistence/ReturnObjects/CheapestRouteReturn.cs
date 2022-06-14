using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRoutePersistence.Model;

namespace TravelRoute.Persistence.ReturnObjects
{
    public class CheapestRouteReturn
    {
        public CheapestRouteReturn()
        {
            Routes = new List<Route>();
        }
        public List<Route> Routes { get; set; }
        public double TotalAmount { get; set; }
    }
}
