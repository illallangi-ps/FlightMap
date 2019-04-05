namespace Illallangi.FlightMap.Segments
{
    public static class SegmentExtensionMethods
    {
        public static ISegment ToSegment(this ISegment segment)
        {
            return new Segment
            {
                OriginElevation = segment.OriginElevation,
                OriginLatitude = segment.OriginLatitude,
                OriginLongitude = segment.OriginLongitude,
                DestinationElevation = segment.DestinationElevation,
                DestinationLatitude = segment.DestinationLatitude,
                DestinationLongitude = segment.DestinationLongitude
            };
        }
    }
}
