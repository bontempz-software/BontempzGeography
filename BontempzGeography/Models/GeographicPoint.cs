using NetTopologySuite.Geometries;

namespace BontempzGeography.Models
{
    public class GeographicPoint
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int SRID { get; set; }
        public Point Point { get; set; }

        public GeographicPoint(double latitude, double longitude, int srid = 4326)
        {
            Latitude = latitude;
            Longitude = longitude;
            SRID = srid;
            Point = new Point(longitude, latitude) { SRID = srid };
        }
    }
}
