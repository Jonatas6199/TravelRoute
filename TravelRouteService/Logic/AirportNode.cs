using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRoute.Service.Logic
{
    public class AirportNode
    {
        public string Name { get; }
        private readonly List<AirportEdge> AirportEdges;

        public AirportNode(string airportName)
        {
            this.Name = airportName;
            AirportEdges = new List<AirportEdge>();
        }

        public List<NeighborhoodInfo> GetNeighbors()
        {
            List<NeighborhoodInfo> neighborhoodInfos = new List<NeighborhoodInfo>();
            foreach (var airportEdge in AirportEdges)
            {
                AirportNode node = airportEdge.Node1 == this ? airportEdge.Node2 : airportEdge.Node1;
                neighborhoodInfos.Add(new NeighborhoodInfo(node, airportEdge.Value));
            }
            return neighborhoodInfos;
        }

        public void Assign(AirportEdge edge)
        {
            AirportEdges.Add(edge);
        }

        public void ConnectTo(AirportNode other, double connectionValue)
        {
            AirportEdge.Create(connectionValue, this, other);
        }

        public class NeighborhoodInfo
        {
            public AirportNode Node { get; }
            public double CostToNode { get; }

            public NeighborhoodInfo(AirportNode node, double costToNode)
            {
                Node = node;
                CostToNode = costToNode;
            }
        }

    }
}
