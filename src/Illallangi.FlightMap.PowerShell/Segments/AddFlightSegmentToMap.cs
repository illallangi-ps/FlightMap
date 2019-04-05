using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using Illallangi.FlightMap.Maps;
using Illallangi.FlightMap.Airports;

namespace Illallangi.FlightMap.Segments
{
    [Cmdlet(VerbsCommon.Add, "FlightSegmentToMap")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public class AddFlightSegmentToMap : PSCmdlet, IMap, ISegment
    {
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Background { get; set; } = @"Nasa";

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public IList<ISegment> Segments { get; set; } = new List<ISegment>();

        [Parameter(Mandatory = true)]
        public string Origin { get; set; }

        [Parameter(Mandatory = true)]
        public string Destination { get; set; }

        public double OriginElevation => Airport.FromIata(Origin).Elevation;

        public double OriginLatitude => Airport.FromIata(Origin).Latitude;

        public double OriginLongitude => Airport.FromIata(Origin).Longitude;

        public double DestinationElevation => Airport.FromIata(Destination).Elevation;

        public double DestinationLatitude => Airport.FromIata(Destination).Latitude;

        public double DestinationLongitude => Airport.FromIata(Destination).Longitude;

        protected override void ProcessRecord()
        {
            WriteObject(this.ToMap().AddSegment(this.ToSegment()));
        }
    }
}
