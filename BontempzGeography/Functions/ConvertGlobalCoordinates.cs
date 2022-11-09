namespace BontempzGeography.Functions
{
    public static class ConvertGlobalCoordinates
    {
        public static double ConvertLatOrLongToDouble(string point)
        {
            int reverseSign = point.Contains("S") || point.Contains("W") ? -1 : 1;
            point = System.Text.RegularExpressions.Regex.Replace(point, "[^0-9 ]", "");
            string[] pointArray = point.Split(' ');

            double degrees = double.Parse(pointArray[0]);
            double minutes = double.Parse(pointArray[1]) / 60;
            double seconds = double.Parse(pointArray[2]) / 3600;

            return (degrees + minutes + seconds) * reverseSign;
        }

        public static double ConvertLatOrLongToDouble(double degrees, double minutes, double seconds,
            string cardinalDirection)
        {
            int reverseSign = cardinalDirection.Substring(1, 1).ToLower() == "s" ||
                cardinalDirection.Substring(1, 1).ToLower() == "w" ? -1 : 1;

            double _minutes = minutes / 60;
            double _seconds = seconds / 3600;

            return (degrees + _minutes + _seconds) * reverseSign;
        }

        public static string ConvertLatLongToString(double latitude, double longitude,
            bool padValues = false, bool includeSymbols = false, bool includeCardinalDirectionName = false)
        {
            int secondsLat = (int)Math.Round(latitude * 3600);
            int degreesLat = secondsLat / 3600;
            secondsLat = Math.Abs(secondsLat % 3600);
            int minutesLat = secondsLat / 60;
            secondsLat %= 60;

            int secondsLong = (int)Math.Round(longitude * 3600);
            int degreesLong = secondsLong / 3600;
            secondsLong = Math.Abs(secondsLong % 3600);
            int minutesLong = secondsLong / 60;
            secondsLong %= 60;

            string cardinalDirectionLatitude = latitude < 0 ? "S" : "N";
            string cardinalDirectionLongitude = longitude < 0 ? "W" : "E";
            string degreesLatitude = Math.Abs(degreesLat).ToString();
            string minutesLatitude = minutesLat.ToString();
            string secondsLatitude = secondsLat.ToString();
            string degreesLongitude = Math.Abs(degreesLong).ToString();
            string minutesLongitude = minutesLong.ToString();
            string secondsLongitude = secondsLong.ToString();

            if (padValues)
            {
                degreesLatitude = degreesLatitude.PadLeft(3, '0');
                minutesLatitude = minutesLatitude.PadLeft(2, '0');
                secondsLatitude = secondsLatitude.PadLeft(2, '0');
                degreesLongitude = degreesLongitude.PadLeft(3, '0');
                minutesLongitude = minutesLongitude.PadLeft(2, '0');
                secondsLongitude = secondsLongitude.PadLeft(2, '0');
            }

            if (includeSymbols)
            {
                degreesLatitude += "°";
                minutesLatitude += "\'";
                secondsLatitude += "\"";
                degreesLongitude += "°";
                minutesLongitude += "\'";
                secondsLongitude += "\"";
            }

            if (includeCardinalDirectionName)
            {
                cardinalDirectionLatitude = cardinalDirectionLatitude.Replace("N", "North");
                cardinalDirectionLatitude = cardinalDirectionLatitude.Replace("S", "South");
                cardinalDirectionLongitude = cardinalDirectionLongitude.Replace("E", "East");
                cardinalDirectionLongitude = cardinalDirectionLongitude.Replace("W", "West");
            }

            return string.Format("{0} {1} {2} {3}, {4} {5} {6} {7}",
                degreesLatitude, minutesLatitude, secondsLatitude, latitude < 0 ? "S" : "N",
                degreesLongitude, minutesLongitude, secondsLongitude, longitude < 0 ? "W" : "E");
        }
    }
}