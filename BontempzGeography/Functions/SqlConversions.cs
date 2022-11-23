using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace BontempzGeography.Functions
{
    public static class SqlConversions
    {
        public static Point GetPoint(Point point)
        {
            var _geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            return _geometryFactory.CreatePoint(point.Coordinate);
        }

        public static Point GetPoint(Coordinate point)
        {
            var _geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            return _geometryFactory.CreatePoint(point);
        }

        public static Polygon GetPolygon(Polygon polygon)
        {
            var _geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            return _geometryFactory.CreatePolygon(polygon.Coordinates);
        }

        public static Polygon GetPolygon(Coordinate[] coordinates)
        {
            var _geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            return _geometryFactory.CreatePolygon(coordinates);
        }
    }
}
