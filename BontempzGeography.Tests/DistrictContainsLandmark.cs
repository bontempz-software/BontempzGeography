using BontempzGeography.DataSource;

namespace BontempzGeography.Tests
{
    public class DistrictContainsLandmark
    {
        [Fact(DisplayName = "Validate Melbourne CBD Landmarks")]
        public void ValidateMelbourneCbdLandmarks()
        {
            var melbourneCbd = MunicipalDistrict.GetById("3141c61f-8102-4ea9-ab94-369529dbb2af");

            var flindersStreetStation = Landmark.GetById("1901d9b7-7f37-49a9-9694-f5d221e76b78");
            var parliamentStation = Landmark.GetById("e519c3dd-9239-4222-b4fc-9bc6a011b7c1");
            var melbourneCentralStation = Landmark.GetById("8652e5f8-53ed-4d99-a601-c5a44dd6573e");
            var flagstaffStation = Landmark.GetById("50db8f48-b088-403a-810c-edc5c80de247");
            var southernCrossStation = Landmark.GetById("c37105e9-d103-4e92-b881-f17820437f71");

            Assert.True(melbourneCbd.Bounds.Intersects(flindersStreetStation.Location), "Flinders Street Station failed.");
            Assert.True(melbourneCbd.Bounds.Intersects(parliamentStation.Location), "Parliament Station failed.");
            Assert.True(melbourneCbd.Bounds.Intersects(melbourneCentralStation.Location), "Melbourne Central Station failed.");
            Assert.True(melbourneCbd.Bounds.Intersects(flagstaffStation.Location), "Flagstaff Station failed.");
            Assert.True(melbourneCbd.Bounds.Intersects(southernCrossStation.Location), "Southern Cross Station failed.");
        }

        [Fact(DisplayName = "Validate Melbourne CBD Landmarks")]
        public void ValidateSydneyLandmarks()
        {
            var circularQuay = MunicipalDistrict.GetById("44207393-e449-4938-9bfd-5258ec7111ec");
            var kingsCross = MunicipalDistrict.GetById("18495290-4e7f-4a6f-82d3-64ae1a16c659");
            var oxfordStreet = MunicipalDistrict.GetById("d87b8368-8fcc-4d1c-bcb2-25a5dff07081");
            var theRocks = MunicipalDistrict.GetById("91fe3d5b-bf30-4580-8bbb-c99cabd11ed0");

            var circularQuayStation = Landmark.GetById("676700c7-ddb1-46a7-8f34-2041efbea995");
            var circularQuayMca = Landmark.GetById("08fc7075-6511-4c4d-af77-e93c5e18ba29");
            var circularQuayOperaHouse = Landmark.GetById("b432c32e-7d1d-4a33-b4e3-d1212cd6054e");

            var cocaColaBillboard = Landmark.GetById("f1240d0c-26af-4327-8b27-6d9be62280dc");

            var taylorSquare = Landmark.GetById("b1970766-d656-4dfc-be03-9e373c050513");

            var mcaRocks = Landmark.GetById("f3ee85d0-d18e-4e9f-90c1-5cc08c8e2c4a");

            Assert.True(circularQuay.Bounds.Intersects(circularQuayStation.Location), "Circular Quay Station failed.");
            Assert.True(circularQuay.Bounds.Intersects(circularQuayMca.Location), "Circular Quay MCA failed.");
            Assert.True(circularQuay.Bounds.Intersects(circularQuayOperaHouse.Location), "Opera House failed.");

            Assert.True(kingsCross.Bounds.Intersects(cocaColaBillboard.Location), "Coca Cola Billboard failed.");

            Assert.True(oxfordStreet.Bounds.Intersects(taylorSquare.Location), "Taylor Square failed.");

            Assert.True(theRocks.Bounds.Intersects(mcaRocks.Location), "MCA Rocks failed.");
        }
    }
}
