using BontempzGeography.Enums.UnitsOfMeasurement;
using BontempzGeography.Models;
using NetTopologySuite.Geometries;

namespace BontempzGeography.Functions
{
    public static class GeographyFunctions
    {
        public static Polygon GetGeographicArea(string coordPairsLongLatCommaSeparated)
        {
            string removeSpaceBetweenPairs = coordPairsLongLatCommaSeparated.Replace(", ", ",");
            string[] splitIntoPairs = removeSpaceBetweenPairs.Split(",");
            int numberOfPairs = splitIntoPairs.Length;
            Coordinate[] coordinates = new Coordinate[numberOfPairs];
            int index = 0;

            foreach (var pair in splitIntoPairs)
            {
                string[] longAndLat = pair.Split(" ");
                coordinates[index] = new Coordinate(double.Parse(longAndLat[0]), double.Parse(longAndLat[1]));
                index++;
            }

            return GetGeographicArea(coordinates);
        }

        public static Polygon GetGeographicArea(List<GeographicPoint> pointList)
        {
            Coordinate[] coordinates = new Coordinate[pointList.Count()];
            int index = 0;

            foreach (GeographicPoint point in pointList)
            {
                coordinates[index] = new Coordinate(point.Longitude, point.Latitude);
                index++;
            }

            return GetGeographicArea(coordinates);
        }

        public static Polygon GetGeographicArea(List<Point> pointList)
        {
            Coordinate[] coordinates = new Coordinate[pointList.Count()];
            int index = 0;

            foreach (Point point in pointList)
            {
                coordinates[index] = new Coordinate(point.X, point.Y);
                index++;
            }

            return GetGeographicArea(coordinates);
        }

        public static Polygon GetGeographicArea(Coordinate[] coordinates)
        {
            LinearRing linearRing = new LinearRing(coordinates);

            return new Polygon(linearRing);
        }

        public static double DistanceBetweenPoints(GeographicPoint origin, Point destination, Distance distance = Distance.Metre)
        {
            return DistanceBetweenPoints(origin, new GeographicPoint(destination.Y, destination.X), distance);
        }

        public static double DistanceBetweenPoints(Point origin, GeographicPoint destination, Distance distance = Distance.Metre)
        {
            return DistanceBetweenPoints(new GeographicPoint(origin.Y, origin.X), destination, distance);
        }

        public static double DistanceBetweenPoints(GeographicPoint origin, GeographicPoint destination, Distance distance = Distance.Metre)
        {
            double radiusOfEarth = 6371000; // Radius of Earth in Metres.

            switch (distance)
            {
                case Distance.Kilometre:
                    radiusOfEarth = radiusOfEarth / 1000; // Radius of Earth in Kilometres.
                    break;
                case Distance.Mile:
                    radiusOfEarth = 3956; // Radius of Earth in Miles.
                    break;
            }

            // Haversine formula
            double differenceLatitude = degreeToRadians(destination.Latitude) - degreeToRadians(origin.Latitude);
            double differenceLongitude = degreeToRadians(destination.Longitude) - degreeToRadians(origin.Longitude);

            double a = Math.Pow(Math.Sin(differenceLatitude / 2), 2) +
                (Math.Cos(degreeToRadians(origin.Latitude)) * Math.Cos(degreeToRadians(destination.Latitude)) *
                Math.Pow(Math.Sin(differenceLongitude / 2), 2));

            double c = 2 * Math.Asin(Math.Sqrt(a));

            double calculatedDistance = c * radiusOfEarth;

            return calculatedDistance;
        }

        private static double degreeToRadians(double longitudeOrLatitude)
        {
            var radian = longitudeOrLatitude * Math.PI / 180;
            return radian;
        }
    }
}
