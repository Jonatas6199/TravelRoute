using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRoute.Persistence.ReturnObjects;
using TravelRoute.Service.Logic;
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
        private List<AirportNode> GetAirportNodes(IEnumerable<Route> routes)
        {
            List<AirportNode> nodes = new List<AirportNode>();

            foreach (var item in routes)
            {
                var _origin = item.Origin;
                var destiny = item.Destination;

                if (nodes.Find(e => e.Name == _origin) == null)
                {
                    nodes.Add(new AirportNode(_origin));
                }
                if (nodes.Find(e => e.Name == destiny) == null)
                {
                    nodes.Add(new AirportNode(destiny));
                }
            }
            return nodes;
        }
        private void ConnectAirportNodes(List<Route> routes, List<AirportNode> nodes)
        {
            foreach (var item in routes)
            {
                var origin = nodes.Find(n => n.Name == item.Origin);
                var destination = nodes.Find(n => n.Name == item.Destination);
                origin.ConnectTo(destination, item.Value);
            }
        }
        public CheapestRouteReturn GetCheapestRoute(string origin, string destination)
        {
            CheapestRouteReturn cheapestRouteReturn = new ();
            var routes = _travelRouteRepository.GetTravelRoutes();
            List<AirportNode> nodes = GetAirportNodes(routes);
            ConnectAirportNodes(routes, nodes);
            AirportNode originNode = nodes.Find(r => r.Name == origin);
            AirportNode destinationNode = nodes.Find(r => r.Name == destination);
            var path = DijkstraAlgorithm.FindShortestPath(originNode, destinationNode);

            for (int i = 0; i < path.Length - 1 ; i++)
            {
                var currentPath = path[i];
                var pathConnection = path[i + 1];

               var route =  routes.Find(r => r.Origin == currentPath.Name && r.Destination == pathConnection.Name);
                cheapestRouteReturn.Routes.Add(route);
                cheapestRouteReturn.TotalAmount += route.Value;
            }

            return cheapestRouteReturn;
        }

        public Route GetTravelRouteByRoute(Route route)
        {
           return _travelRouteRepository.GetTravelRoutes().Find(
                r => r.Origin == route.Origin && r.Destination == route.Destination);
        }

        public bool VerifyIfAirportNodesExistInRoutes(string originAirport, string destinyAirport)
        {
            var routes = _travelRouteRepository.GetTravelRoutes();
            if(routes.Find(r=> r.Origin == originAirport) != null && routes.Find(r => r.Destination == destinyAirport) != null)
                return true;
            return false;
        }
    }
}
