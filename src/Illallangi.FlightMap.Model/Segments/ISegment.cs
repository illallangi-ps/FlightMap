namespace Illallangi.FlightMap.Segments
{
    public interface ISegment
    {
        double OriginElevation { get; }
        double OriginLatitude { get; }
        double OriginLongitude { get; }
        double DestinationElevation { get; }
        double DestinationLatitude { get; }
        double DestinationLongitude { get; }
    }
}
