using System.Collections.Generic;

using Illallangi.FlightMap.Segments;

namespace Illallangi.FlightMap.Maps
{
    public class Map : IMap
    {
        public string Background { get; set; }
        public IList<ISegment> Segments { get; set; } = new List<ISegment>();
    }
}
