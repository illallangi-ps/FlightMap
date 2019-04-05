using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Management.Automation;
using Illallangi.FlightMap.Segments;

namespace Illallangi.FlightMap.Maps
{
    [Cmdlet(VerbsCommon.New, @"Map")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public class NewMap : PSCmdlet, IMap
    {
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Background { get; set; } = @"Nasa";

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public IList<ISegment> Segments { get; set; } = new List<ISegment>();

        protected override void ProcessRecord()
        {
            WriteObject(this.ToMap());
        }
    }
}
