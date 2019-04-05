using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;

namespace Illallangi.FlightMap.Airports
{
    [Cmdlet(VerbsCommon.Get, @"Route")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed class GetRoute : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateLength(3, 3)]
        [ValidateNotNullOrEmpty]
        public string OriginIata { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateLength(3, 3)]
        [ValidateNotNullOrEmpty]
        public string DestinationIata { get; set; }

        private List<Feature> _features = new List<Feature>();

        protected override void ProcessRecord()
        {
            var origin = Airport.FromIata(OriginIata);
            var destination = Airport.FromIata(DestinationIata);

            _features.Add(new Feature(
                new LineString(new[]
                {
                    new Position(origin.Latitude, origin.Longitude, origin.Elevation / 3.2808399),
                    new Position(destination.Latitude, destination.Longitude, destination.Elevation / 3.2808399),
                }),
                new Dictionary<string, object>
                {
                    {"featurecla", @"route"},
                    {"originicao", origin.Icao},
                    {"originiata", origin.Iata},
                    {"originname", origin.Name},
                    {"origincity", origin.City},
                    {"originstate", origin.State},
                    {"origincountry", origin.Country},
                    {"origintz", origin.Timezone},
                    {"destinationicao", destination.Icao},
                    {"destinationiata", destination.Iata},
                    {"destinationname", destination.Name},
                    {"destinationcity", destination.City},
                    {"destinationstate", destination.State},
                    {"destinationcountry", destination.Country},
                    {"destinationtz", destination.Timezone},
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
