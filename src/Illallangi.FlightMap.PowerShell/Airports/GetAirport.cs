using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Management.Automation;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;

namespace Illallangi.FlightMap.Airports
{
    [Cmdlet(VerbsCommon.Get, @"Airport")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed class GetAirport : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        [ValidateLength(3,3)]
        [ValidateNotNullOrEmpty]
        public string Iata { get; set; }

        private List<Feature> _features = new List<Feature>();

        protected override void ProcessRecord()
        {
            var airport = Airport.FromIata(Iata);

            _features.Add(new Feature(
                new Point(new Position(airport.Latitude, airport.Longitude, airport.Elevation / 3.2808399)),
                new Dictionary<string, object>
                {
                    {"icao", airport.Icao},
                    {"iata", airport.Iata},
                    {"name", airport.Name},
                    {"featurecla", @"airport"},
                    {"city", airport.City},
                    {"state", airport.State},
                    {"country", airport.Country},
                    {"tz", airport.Timezone},
                }));
        }

        protected override void EndProcessing()
        {
            if (_features.Count == 1)
            {
                WriteObject(JsonConvert.SerializeObject(_features[0], Formatting.Indented));
            }

            if (_features.Count > 1)
            {
                WriteObject(JsonConvert.SerializeObject(new FeatureCollection(_features), Formatting.Indented));
            }
        }
    }
}
