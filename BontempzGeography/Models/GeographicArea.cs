using NetTopologySuite.Geometries;

namespace BontempzGeography.Models
{
    public class GeographicArea
    {
        public Guid Id { get; set; }
        public int SRID { get; set; }
        public Polygon Area { get; set; }
    }
}
