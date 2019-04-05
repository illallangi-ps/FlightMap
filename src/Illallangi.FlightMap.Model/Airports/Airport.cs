using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Illallangi.FlightMap.Airports
{

    public class Airport : IAirport
    {
        public string Iata { get; set; }
        public string Icao { get; set; }
        public double Elevation { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        [JsonProperty("tz")]
        public string Timezone { get; set; }

        public static IAirport FromIata(string iata)
        {
            return FromResource().SingleOrDefault(a => a.Iata.Equals(iata,StringComparison.InvariantCultureIgnoreCase));
        }

        private static Airport[] _fromResource;
        public static IEnumerable<IAirport> FromResource()
        {
            if (_fromResource != null) return _fromResource;

            var serializer = new JsonSerializer();

            using (var stream = Assembly.Load(@"Illallangi.FlightMap.Resources").GetManifestResourceStream(@"Illallangi.FlightMap.Airports.json"))
            using (var sr = new StreamReader(stream ?? throw new InvalidOperationException(@"Illallangi.FlightMap.Airports.json")))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                _fromResource = serializer.Deserialize<Dictionary<string, Airport>>(jsonTextReader)
                    .Values
                    .Where(a => !string.IsNullOrWhiteSpace(a.Iata))
                    .ToArray();
            }
            return _fromResource;
        }
    }
}
