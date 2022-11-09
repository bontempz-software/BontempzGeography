using BontempzHelpers.Enums.UnitsOfMeasurement;
using BontempzHelpers.Geography;
using BontempzHelpers.Models.Locations;

namespace BontempzGeography.Tests
{
    public class GeographicDistances
    {
        const int SRID = 4326;

        GeographicPoint bigBen = new GeographicPoint(51.5007325, -0.1268141, SRID);
        GeographicPoint buckinghamPalaceGuardMuseum = new GeographicPoint(51.50036, -0.13621, SRID);

        GeographicPoint parliamentStation = new GeographicPoint(-37.8140185, 144.9587952, SRID);
        GeographicPoint southernCrossTramStopBourkeStreet = new GeographicPoint(-37.8169623, 144.9516348, SRID);

        [Fact(DisplayName = "Distance between Big Ben and Buckinghan Palace")]
        public void DistanceFromBigBenToBuckinghamPalace()
        {
            var resultMtrs = GeographyFunctions.DistanceBetweenPoints(bigBen, buckinghamPalaceGuardMuseum, Distance.Metre);
            var resultKms = GeographyFunctions.DistanceBetweenPoints(bigBen, buckinghamPalaceGuardMuseum, Distance.Kilometre);
            var resultMiles = GeographyFunctions.DistanceBetweenPoints(bigBen, buckinghamPalaceGuardMuseum, Distance.Mile);

            Assert.True(resultMtrs >= 650 && resultMtrs <= 652, "The distance calculated did not fall within the expected range.");
            Assert.True(resultKms >= 0.65 && resultKms <= 0.652, "The distance calculated did not fall within the expected range.");
            Assert.True(resultMiles >= 0.4 && resultMiles <= 0.41, "The distance calculated did not fall within the expected range.");
        }

        [Fact(DisplayName = "Distance between Melbourne Parliament and Southern Cross Stations")]
        public void DistanceFromMelbourneParliamentToSpringStreet()
        {
            var resultMtrs = GeographyFunctions.DistanceBetweenPoints(parliamentStation, southernCrossTramStopBourkeStreet, Distance.Metre);
            var resultKms = GeographyFunctions.DistanceBetweenPoints(parliamentStation, southernCrossTramStopBourkeStreet, Distance.Kilometre);

            Assert.True(resultMtrs >= 709 && resultMtrs <= 710, string.Format("Expected 709 - 710 Metres. Received {0} Metres.", resultMtrs));
            Assert.True(resultKms >= 0.709 && resultKms <= 0.71, string.Format("Expected .0709 - 0.71 Kms. Received {0} Kms.", resultKms));
        }
    }
}
