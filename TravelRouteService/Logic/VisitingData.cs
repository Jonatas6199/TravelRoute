using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRoute.Service.Logic
{
    public class VisitingData
    {
        private readonly List<AirportNode> visitedNodes;
        private readonly List<AirportNode> scheduledVisitis;
        private readonly Dictionary<AirportNode, Weight> weights;

        public VisitingData()
        {
            visitedNodes = new List<AirportNode>();
            scheduledVisitis = new List<AirportNode>();
            weights = new Dictionary<AirportNode, Weight>();
        }

        public void RegisterVisitTo(AirportNode node)
        {
            if (!visitedNodes.Contains(node))
                visitedNodes.Add((node));
        }

        public bool WasVisited(AirportNode node)
        {
            return visitedNodes.Contains(node);
        }

        public void UpdateWeight(AirportNode node, Weight newWeight)
        {
            if (!weights.ContainsKey(node))
            {
                weights.Add(node, newWeight);
            }
            else
            {
                weights[node] = newWeight;
            }
        }

        public Weight QueryWeight(AirportNode node)
        {
            Weight result;
            if (!weights.ContainsKey(node))
            {
                result = new Weight(null, int.MaxValue);
                weights.Add(node, result);
            }
            else
            {
                result = weights[node];
            }
            return result;
        }

        public void ScheduleVisitTo(AirportNode node)
        {
            scheduledVisitis.Add(node);
        }

        public bool HasScheduledVisits => scheduledVisitis.Count > 0;

        public AirportNode GetNodeToVisit()
        {
            var ordered = from n in scheduledVisitis
                          orderby QueryWeight(n).Value
                          select n;

            var result = ordered.First();
            scheduledVisitis.Remove(result);
            return result;
        }

        public bool HasComputedPathToOrigin(AirportNode node)
        {
            return QueryWeight(node).From != null;
        }

        public IEnumerable <AirportNode> ComputedPathToOrigin(AirportNode node)
        {
            var n = node;
            while (n != null)
            {
                yield return n;
                n = QueryWeight(n).From;
            }
        }
    }
}
