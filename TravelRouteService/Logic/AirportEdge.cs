using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRoute.Service.Logic
{
    public class AirportEdge
    {
        public double Value { get; }
        public AirportNode Node1 { get; }
        public AirportNode Node2 { get; }

        public AirportEdge(double value, AirportNode node1, AirportNode node2)
        {
            Value = value;
            Node1 = node1;
            node1.Assign(this);
            Node2 = node2;
            node2.Assign(this);
        }

        public static AirportEdge Create(double value, AirportNode node1, AirportNode node2)
        {
            return new AirportEdge(value, node1, node2);
        }
    }
}
