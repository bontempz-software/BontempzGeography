using BontempzGeography.DataSource;
using BontempzGeography.Models;
using NetTopologySuite.Geometries;

namespace BontempzGeography.Tests
{
    public class DistrictIntersections
    {
        const string FunnyFailMessage = "Something is rotten in the State of Denmark.";

        Point bridieOreillys = new GeographicPoint(-37.843548, 144.994863).Point;
        Point fifthProvince = new GeographicPoint(-37.8595190, 144.9775000).Point;
        Point goatHouse = new GeographicPoint(-37.8844332, 145.0008658).Point;
        Point laDiDa = new GeographicPoint(-37.8154925, 144.9555337).Point;
        Point youngAndJackson = new GeographicPoint(-37.8174228, 144.9671155).Point;

        [Fact(DisplayName = "Validate Melbourne CBD Venues")]
        public void ValidateMelbourneCbdVenues()
        {
            var districtList = RegionalDistricts.List();
            var districtsMelbourneMetro = RegionalDistricts.List("Melbourne");
            var melbourneCbd = RegionalDistricts.GetById("3141c61f-8102-4ea9-ab94-369529dbb2af");

            Assert.True(districtList.Any(), FunnyFailMessage);
            Assert.True(districtsMelbourneMetro.Any(), FunnyFailMessage);

            AssertDistrictContainsPoint(laDiDa, melbourneCbd);
            AssertDistrictContainsPoint(youngAndJackson, melbourneCbd);
            FailDistrictContainsPoint(bridieOreillys, melbourneCbd);
            FailDistrictContainsPoint(fifthProvince, melbourneCbd);
            FailDistrictContainsPoint(goatHouse, melbourneCbd);
        }

        private void AssertDistrictContainsPoint(Point point, District district)
        {
            Assert.True(point.Intersects(district.Bounds), String.Format("Point at {0} Lat {1} Long is not within {2}.", point.X, point.Y, district.Name));
        }

        private void FailDistrictContainsPoint(Point point, District district)
        {
            Assert.False(point.Intersects(district.Bounds), String.Format("Point at {0} Lat {1} Long IS within {2}.", point.X, point.Y, district.Name));
        }
    }
}