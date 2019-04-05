using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;

namespace Illallangi.FlightMap.Airports
{
    [Cmdlet(VerbsCommon.New, @"Airport")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public class NewAirport : PSCmdlet, IAirport
    {
        [Parameter(Mandatory=true, ValueFromPipelineByPropertyName = true)]
        public string Icao { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Iata { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public double Elevation { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public double Latitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public double Longitude { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string City { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string State { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Country { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Timezone { get; set; }

        protected override void ProcessRecord()
        {
            WriteObject(this.ToAirport());
        }
    }
}
