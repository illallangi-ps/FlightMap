using System;

namespace Illallangi.FlightMap
{
    public static class DoubleExtensionMethods
    {
        public static int ToXCoordinate(this double longitude, int width)
        {
            return Convert.ToInt16(width * ((longitude + 180) / 360));
        }

        public static int ToYCoordinate(this double latitude, int height)
        {
            return Convert.ToInt16(height * ((180-(latitude + 90)) / 180));
        }
    }
}
