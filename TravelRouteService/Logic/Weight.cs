using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelRoute.Service.Logic
{
    public class Weight
    {
        public AirportNode From { get; }
        public double Value { get; }

        public Weight(AirportNode @from, double value)
        {
            From = @from;
            Value = value;
        }
    }

}
