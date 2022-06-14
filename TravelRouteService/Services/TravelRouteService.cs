using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRoute.Persistence.ReturnObjects;
using TravelRoutePersistence.Interfaces;
using TravelRoutePersistence.Model;
using TravelRoutePersistence.Repository;
using TravelRouteService.Interfaces;

namespace TravelRouteService.Services
{
    public class TravelRouteService : ITravelRouteService
    {
        private readonly ITravelRouteRepository _travelRouteRepository;
        
        public TravelRouteService(ITravelRouteRepository travelRouteRepository)
        {
            _travelRouteRepository = travelRouteRepository;
        }

        public bool AddTravelRoute(Route travelRoute)
        {
            try
            {
                _travelRouteRepository.AddTravelRoute(travelRoute);
                _travelRouteRepository.Save();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteTravelRoute(int travelRouteId)
        {
            try
            {
                _travelRouteRepository.DeleteRoute(travelRouteId);
                _travelRouteRepository.Save();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public Route GetTravelRouteById(int travelRouteId)
        {
            try
            {
                return _travelRouteRepository.GetTravelRoute(travelRouteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Route> GetTravelRoutes()
        {
            try
            {
                return _travelRouteRepository.GetTravelRoutes();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateTravelRoute(Route travelRoute)
        {
            try
            {
                _travelRouteRepository.UpdateTravelRoute(travelRoute);
                _travelRouteRepository.Save();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CheapestRouteReturn GetCheapestRoute(string origin, string destination)
        {
            CheapestRouteReturn cheapestRouteReturn = new ();
            var routes = _travelRouteRepository.GetTravelRoutes();

            bool hasOptions = true;
            while (hasOptions)
            {
                var originRoutes = routes.Where(r => r.Origin == origin);
            }
            foreach (var item in routes)
            {
                if(item.Origin == origin)
                {

                }
            }

            return cheapestRouteReturn;
        }
    }
}
