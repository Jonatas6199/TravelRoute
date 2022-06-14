using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRoute.Persistence.ReturnObjects;
using TravelRoutePersistence.Model;

namespace TravelRouteService.Interfaces
{
    public interface ITravelRouteService
    {
        bool AddTravelRoute(Route travelRoute);
        bool DeleteTravelRoute(int travelRouteId);
        bool UpdateTravelRoute(Route travelRoute);
        IEnumerable<Route> GetTravelRoutes();
        Route GetTravelRouteById(int travelRouteId);
        CheapestRouteReturn GetCheapestRoute(string origin, string destination);
    }
}
