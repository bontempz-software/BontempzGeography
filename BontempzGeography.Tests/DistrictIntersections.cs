using BontempzGeography.DataSource;
using BontempzHelpers.Geography;
using Microsoft.SqlServer.Types;

namespace BontempzGeography.Tests
{
    public class DistrictIntersections
    {
        const string FunnyFailMessage = "Something is rotten in the State of Denmark.";

        SqlGeography bridieOreillys = GeographyFunctions.GetGeographyPoint(-37.843548, 144.994863).SqlGeography;
        SqlGeography fifthProvince = GeographyFunctions.GetGeographyPoint(-37.8595190, 144.9775000).SqlGeography;
        SqlGeography goatHouse = GeographyFunctions.GetGeographyPoint(-37.8844332, 145.0008658).SqlGeography;
        SqlGeography laDiDa = GeographyFunctions.GetGeographyPoint(-37.8154925, 144.9555337).SqlGeography;
        SqlGeography youngAndJackson = GeographyFunctions.GetGeographyPoint(-37.8174228, 144.9671155).SqlGeography;

        [Fact]
        public void ValidateMelbourneCbdVenues()
        {
            var districtList = DistrictEntity.List();
            var districtsMelbourneMetro = DistrictEntity.List("Melbourne");
            var melbourneCbd = DistrictEntity.GetById("3141c61f-8102-4ea9-ab94-369529dbb2af");

            Assert.True(districtList.Any(), FunnyFailMessage);
            Assert.True(districtsMelbourneMetro.Any(), FunnyFailMessage);

            AssertDistrictContainsPoint(laDiDa, melbourneCbd);
            AssertDistrictContainsPoint(youngAndJackson, melbourneCbd);
            FailDistrictContainsPoint(bridieOreillys, melbourneCbd);
            FailDistrictContainsPoint(fifthProvince, melbourneCbd);
            FailDistrictContainsPoint(goatHouse, melbourneCbd);
        }

        private void AssertDistrictContainsPoint(SqlGeography point, District district)
        {
            Assert.True((bool)point.STIntersects(district.SqlGeography), String.Format("Point at {0} Lat {1} Long is not within {2}.", point.Lat, point.Long, district.Name));
        }

        private void FailDistrictContainsPoint(SqlGeography point, District district)
        {
            Assert.False((bool)point.STIntersects(district.SqlGeography), String.Format("Point at {0} Lat {1} Long IS within {2}.", point.Lat, point.Long, district.Name));
        }
    }
}