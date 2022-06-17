using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRoutePersistence.Model;

namespace TravelRoutePersistence.Interfaces
{
    public interface ITravelRouteRepository
    {
        List<Route> GetTravelRoutes();
        Route GetTravelRoute(int travelRouteId);
        void AddTravelRoute(Route travelRoute);
        void DeleteRoute(int travelRouteId);
        void UpdateTravelRoute(Route travelRoute);
        void Save();
    }
}
