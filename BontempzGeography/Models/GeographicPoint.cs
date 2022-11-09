using NetTopologySuite.Geometries;

namespace BontempzGeography.Models
{
    public class GeographicPoint
    {
        public GeographicPoint(Guid id, double latitude, double longitude, int srid = 4326)
        {
            Id= id;
            Latitude = latitude;
            Longitude = longitude;
            SRID = srid;
            Point = new Point(longitude, latitude) { SRID = srid };
        }

        public GeographicPoint(double latitude, double longitude, int srid = 4326)
        {
            Latitude = latitude;
            Longitude = longitude;
            SRID = srid;
            Point = new Point(longitude, latitude) { SRID = srid };
        }

        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int SRID { get; set; }
        public Point Point { get; set; }

    }
}
