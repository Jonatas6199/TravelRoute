using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRoutePersistence.DatabaseContext;
using TravelRoutePersistence.Interfaces;
using TravelRoutePersistence.Model;

namespace TravelRoutePersistence.Repository
{
    public class TravelRouteRepository : ITravelRouteRepository
    {
        TravelRouteContext context;
        public TravelRouteRepository(TravelRouteContext context)
        {
            this.context = context;
        }
        public void AddTravelRoute(Route travelRoute)
        {
            context.TravelRoutes.Add(travelRoute);
        }

        public void DeleteRoute(int travelRouteId)
        {
            Route route = GetTravelRouteById(travelRouteId);
            if (route != null)
                context.TravelRoutes.Remove(route);
        }

        public Route GetTravelRoute(int travelRouteId)
        {
            return GetTravelRouteById(travelRouteId);
        }

        public IEnumerable<Route> GetTravelRoutes()
        {
            return context.TravelRoutes.ToList();
        }

        public void UpdateTravelRoute(Route travelRoute)
        {
            context.Entry(travelRoute).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        private Route GetTravelRouteById(int travelRouteId)
        {
            return context.TravelRoutes.Find(travelRouteId);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
