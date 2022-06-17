using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRoute.Service.Logic
{
    public static class DijkstraAlgorithm
    {
        public static AirportNode[] FindShortestPath(AirportNode origin, AirportNode destiny)
        {
            var control = new VisitingData();

            control.UpdateWeight(origin, new Weight(null, 0));
            control.ScheduleVisitTo(origin);

            while (control.HasScheduledVisits)
            {
                var visitingNode = control.GetNodeToVisit();
                var visitingNodeWeight = control.QueryWeight(visitingNode);
                control.RegisterVisitTo(visitingNode);

                var neighbours = visitingNode.GetNeighbors();

                foreach (var neighborhoodInfo in neighbours)
                {
                    if (!control.WasVisited(neighborhoodInfo.Node))
                    {
                        control.ScheduleVisitTo(neighborhoodInfo.Node);
                    }

                    var neighborWeight = control.QueryWeight(neighborhoodInfo.Node);

                    var probableWeight = (visitingNodeWeight.Value + neighborhoodInfo.CostToNode);
                    if (neighborWeight.Value > probableWeight)
                    {
                        control.UpdateWeight(neighborhoodInfo.Node, new Weight(visitingNode, probableWeight));
                    }
                }
            }

            return control.HasComputedPathToOrigin(destiny)
                ? control.ComputedPathToOrigin(destiny).Reverse().ToArray()
                : null;
        }
    }
}
