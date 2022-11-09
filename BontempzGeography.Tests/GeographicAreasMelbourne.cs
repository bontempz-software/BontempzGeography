﻿using BontempzHelpers.Enums.UnitsOfMeasurement;
using BontempzHelpers.Geography;
using BontempzHelpers.Models.Locations;
using NetTopologySuite.Geometries;

namespace BontempzGeography.Tests
{
    public class GeographicAreasMelbourne
    {
        Polygon melbourneCBD = GeographyFunctions.GetGeographyArea("144.9498796 -37.8131744, 144.9554586 -37.8233109, 144.9712086 -37.8190395, 144.9757576 -37.8160223, 144.9714661 -37.8071054, 144.9714661 -37.8071054, 144.9498796 -37.8131744, 144.9498796 -37.8131744");

        GeographicPoint parliamentStation = new GeographicPoint(-37.8140185, 144.9587952);
        GeographicPoint tramStopBourkeStreetSC = new GeographicPoint(-37.8169623, 144.9516348);

        Point youngAndJackson = new GeographicPoint(-37.8174228, 144.9671155).Point;
        Point laDiDa = new GeographicPoint(-37.8154925, 144.9555337).Point;
        Point bridieOreillys = new GeographicPoint(-37.843548, 144.994863).Point;
        Point fifthProvince = new GeographicPoint(-37.8154925, 144.9555337).Point;
        Point goatHouse = new GeographicPoint(-37.8844332, 145.0008658).Point;

        [Fact(DisplayName = "Distance between Melbourne Parliament and Southern Cross Stations")]
        public void DistanceFromMelbourneParliamentToSpringStreet()
        {
            var resultMtrs = GeographyFunctions.DistanceBetweenPoints(parliamentStation, tramStopBourkeStreetSC, Distance.Metre);
            var resultKms = GeographyFunctions.DistanceBetweenPoints(parliamentStation, tramStopBourkeStreetSC, Distance.Kilometre);

            Assert.True(resultMtrs >= 709 && resultMtrs <= 711, string.Format("Expected 709 - 710 Metres. Received {0} Metres.", resultMtrs));
            Assert.True(resultKms >= 0.709 && resultKms <= 0.711, string.Format("Expected .0709 - 0.71 Kms. Received {0} Kms.", resultKms));
        }

        [Fact(DisplayName = "Retrieve Glen Huntly Road Venues")]
        public void CheckGlenHuntlyRoadVenues()
        {
            List<Point> gleyHuntlyRoadBounds = new List<Point>()
            {
                new Point(144.9959922, -37.8828475),
                new Point(144.996078, -37.8843887),
                new Point(145.0016999, -37.8859129),
                new Point(145.0154972, -37.8868443),
                new Point(145.0157118, -37.8854726),
                new Point(144.9959922, -37.8828475),
            };

            List<GeographicPoint> gleyHuntlyRoadBoundsGeo = new List<GeographicPoint>()
            {
                GeographyFunctions.GetGeographyPoint(-37.8828475, 144.9959922),
                GeographyFunctions.GetGeographyPoint(-37.8843887, 144.996078),
                GeographyFunctions.GetGeographyPoint(-37.8859129, 145.0016999),
                GeographyFunctions.GetGeographyPoint(-37.8868443, 145.0154972),
                GeographyFunctions.GetGeographyPoint(-37.8854726, 145.0157118),
                GeographyFunctions.GetGeographyPoint(-37.8828475, 144.9959922),
            };

            Polygon ghrDistrict = GeographyFunctions.GetGeographyArea(gleyHuntlyRoadBounds);
            Polygon ghrDistrictGeo = GeographyFunctions.GetGeographyArea(gleyHuntlyRoadBoundsGeo);

            Assert.True(goatHouse.Intersects(ghrDistrict), "Goathouse fails to intersect GHR West.");
            Assert.False(bridieOreillys.Intersects(ghrDistrict), "Bridie's falsely intersects with GHR West.");
            Assert.False(fifthProvince.Intersects(ghrDistrict), "The Fifth Province falsely intersects with GHR West.");

            Assert.True(goatHouse.Intersects(ghrDistrictGeo), "Goathouse fails to intersect GHR West.");
            Assert.False(bridieOreillys.Intersects(ghrDistrictGeo), "Bridie's falsely intersects with GHR West.");
            Assert.False(fifthProvince.Intersects(ghrDistrictGeo), "The Fifth Province falsely intersects with GHR West.");
        }
    }
}
