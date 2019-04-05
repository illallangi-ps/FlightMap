namespace Illallangi.FlightMap.Airports
{
    public static class AirportExtensionMethods
    {
        public static IAirport ToAirport(this IAirport airport)
        {
            return new Airport
            {
                Iata = airport.Iata,
                Icao = airport.Icao,
                Elevation = airport.Elevation,
                Latitude = airport.Latitude,
                Longitude = airport.Longitude,
                Name = airport.Name,
                City = airport.City,
                State = airport.State,
                Country = airport.Country,
                Timezone = airport.Timezone,
            };
        }
    }
}
