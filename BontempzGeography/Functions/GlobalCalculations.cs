using BontempzHelpers.Enums.UnitsOfMeasurement;
using BontempzHelpers.Models.Locations;
using NetTopologySuite.Geometries;

namespace BontempzGeography.Functions
{
    public static class GeographyFunctions
    {
        public static Polygon GetGeographyArea(string coordPairsLongLatCommaSeparated)
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

            return GetGeographyArea(coordinates);
        }

        public static Polygon GetGeographyArea(List<GeographicPoint> pointList)
        {
            Coordinate[] coordinates = new Coordinate[pointList.Count()];
            int index = 0;

            foreach(GeographicPoint point in pointList)
            {
                coordinates[index] = new Coordinate(point.Longitude, point.Latitude);
                index++;
            }

            return GetGeographyArea(coordinates);
        }

        public static Polygon GetGeographyArea(List<Point> pointList)
        {
            Coordinate[] coordinates = new Coordinate[pointList.Count()];
            int index = 0;

            foreach (Point point in pointList)
            {
                coordinates[index] = new Coordinate(point.X, point.Y);
                index++;
            }

            return GetGeographyArea(coordinates);
        }

        public static Polygon GetGeographyArea(Coordinate[] coordinates)
        {
            LinearRing linearRing = new LinearRing(coordinates);

            return new Polygon(linearRing);
        }

        public static GeographicPoint GetGeographyPoint(double latitude, double longitude, int srid = 4326)
        {
            GeographicPoint pointModel = new GeographicPoint(latitude, longitude)
            {
                Latitude = latitude,
                Longitude = longitude,
                SRID = srid,
                Point = new Point(longitude, latitude, srid)
            };

            return pointModel;
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
