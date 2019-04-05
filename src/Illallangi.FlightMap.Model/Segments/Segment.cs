namespace Illallangi.FlightMap.Segments
{

    public class Segment : ISegment
    {
        public double OriginElevation { get; set; }
        public double OriginLatitude { get; set; }
        public double OriginLongitude { get; set; }
        public double DestinationElevation { get; set; }
        public double DestinationLatitude { get; set; }
        public double DestinationLongitude { get; set; }
    }
}
