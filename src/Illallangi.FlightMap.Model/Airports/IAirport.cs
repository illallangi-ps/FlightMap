namespace Illallangi.FlightMap.Airports
{
    public interface IAirport
    {
        string Iata { get; }
        string Icao { get; }
        double Elevation { get; }
        double Latitude { get; }
        double Longitude { get; }
        string Name { get; }
        string City { get; }
        string State { get; }
        string Country { get; }
        string Timezone { get; }
    }
}
