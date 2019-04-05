using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using Illallangi.FlightMap.Segments;
using System.Drawing;
using System.Management.Automation;
using System.Reflection;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Illallangi.FlightMap.Maps
{
    [Cmdlet(VerbsData.Export, "MapToPng")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Global")]
    public class ExportMapToPng : PSCmdlet, IMap
    {
        private string _path;

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string Background { get; set; } = @"Nasa";

        [Parameter(ValueFromPipelineByPropertyName = true)]
        public IList<ISegment> Segments { get; set; } = new List<ISegment>();

        [Parameter(Mandatory = true, Position = 0)]
        public string Path { get => _path; set => _path = System.IO.Path.GetFullPath(value); }

        [Parameter()]
        public ImageFormat Format { get; set; } = ImageFormat.Png;

        private ISupportedImageFormat SupportedImageFormat
        {
            get
            {
                switch (Format)
                {
                    case ImageFormat.Bitmap:
                        return new BitmapFormat();
                    case ImageFormat.Jpeg:
                        return new JpegFormat();
                    case ImageFormat.Gif:
                        return new GifFormat();
                    case ImageFormat.Png:
                        return new PngFormat();
                    case ImageFormat.Tiff:
                        return new TiffFormat();
                    default:
                        throw new PSNotImplementedException(Format.ToString());
                }
            }
        }

        protected override void ProcessRecord()
        {
            if (!Format.ToString().ToLower().Equals(System.IO.Path.GetExtension(Path)?.ToLower().TrimStart('.')))
            {
                throw new PSInvalidOperationException($@"Specified extension ({System.IO.Path.GetExtension(Path)}) not valid for specified format (should be .{Format.ToString().ToLower()}).");
            }

            using (var inputStream = Assembly.Load(@"Illallangi.FlightMap.Resources").GetManifestResourceStream($"Illallangi.FlightMap.{Background}.png"))
            using (var imageFactory = new ImageFactory())
            {
                var image = imageFactory.Load(inputStream).Format(SupportedImageFormat).Image;

                var graphics = Graphics.FromImage(image);
                foreach (var segment in Segments)
                {
                    var x1 = segment.OriginLongitude.ToXCoordinate(image.Width);
                    var y1 = segment.OriginLatitude.ToYCoordinate(image.Height);
                    var x2 = segment.DestinationLongitude.ToXCoordinate(image.Width);
                    var y2 = segment.DestinationLatitude.ToYCoordinate(image.Height);

                    graphics.DrawLine(new Pen(Color.Red, 30), x1, y1, x2, y2);
                }
                graphics.Save();

                image.Save(Path);
            }
        }
    }
}
