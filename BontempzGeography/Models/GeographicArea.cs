using BontempzGeography.Functions;
using NetTopologySuite.Geometries;

namespace BontempzGeography.Models
{
    public class GeographicArea
    {
        public GeographicArea(Guid id, string coordinateList, int srid = 4326)
        {
            Id = id;
            SRID = srid;
            Area = GeographyFunctions.GetGeographicArea(coordinateList);
        }

        public GeographicArea(Guid id, Coordinate[] coordinates, int srid = 4326)
        {
            Id = id;
            SRID = srid;
            Area = GeographyFunctions.GetGeographicArea(coordinates);
        }

        public GeographicArea(Guid id, List<Point> coordinates, int srid = 4326)
        {
            Id = id;
            SRID = srid;
            Area = GeographyFunctions.GetGeographicArea(coordinates);
        }

        public GeographicArea(Guid id, List<GeographicPoint> coordinates, int srid = 4326)
        {
            Id = id;
            SRID = srid;
            Area = GeographyFunctions.GetGeographicArea(coordinates);
        }

        public GeographicArea(string coordinateList) {
            Area = GeographyFunctions.GetGeographicArea(coordinateList);
        }

        public GeographicArea(Coordinate[] coordinates, int srid = 4326)
        {
            Id = Guid.NewGuid();
            SRID = srid;
            Area = GeographyFunctions.GetGeographicArea(coordinates);
        }

        public GeographicArea(List<Point> coordinates, int srid = 4326)
        {
            Id = Guid.NewGuid();
            SRID = srid;
            Area = GeographyFunctions.GetGeographicArea(coordinates);
        }

        public GeographicArea(List<GeographicPoint> coordinates, int srid = 4326)
        {
            Id = Guid.NewGuid();
            SRID = srid;
            Area = GeographyFunctions.GetGeographicArea(coordinates);
        }

        public Guid Id { get; set; }
        public int SRID { get; set; }
        public Polygon Area { get; set; }
    }
}
