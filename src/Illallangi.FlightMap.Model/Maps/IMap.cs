using System.Collections.Generic;

using Illallangi.FlightMap.Segments;

namespace Illallangi.FlightMap.Maps
{
    public interface IMap
    {
        string Background { get; }

        IList<ISegment> Segments { get; }
    }
}
