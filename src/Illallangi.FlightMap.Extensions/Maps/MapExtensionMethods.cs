using Illallangi.FlightMap.Segments;

namespace Illallangi.FlightMap.Maps
{
    public static class MapExtensionMethods
    {
        public static IMap ToMap(this IMap map)
        {
            return new Map
            {
                Background = map.Background,
                Segments = map.Segments
            };
        }

        public static IMap AddSegment(this IMap map, ISegment segment)
        {
            map.Segments.Add(segment);
            return map;
        }
    }
}
