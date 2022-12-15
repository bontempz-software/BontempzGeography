using BontempzGeography.DataSource;

namespace BontempzGeography.Tests
{
    public class DistrictsValidation
    {
        [Fact(DisplayName = "Validate Regional Districts")]
        public void ValidateRegionalDistricts()
        {
            var regionalDistricts = RegionalDistrict.List();

            Assert.NotNull(regionalDistricts);
        }

        [Fact(DisplayName = "Validate Municipal Districts")]
        public void ValidateMunicipalDistricts()
        {
            var municipalDistricts = MunicipalDistrict.List();

            Assert.NotNull(municipalDistricts);
        }

        [Fact(DisplayName = "Validate Landmarks")]
        public void ValidateLandmarks()
        {
            var landmarks = Landmark.List();

            Assert.NotNull(landmarks);
        }

        [Fact(DisplayName = "Validate Melbourne CBD Venues")]
        public void ValidateMelbourneCbdVenues()
        {
            string melbourneCbdStringId = "3141c61f-8102-4ea9-ab94-369529dbb2af";
            string melbourneMunicipalDistrictId = "9c967a90-32e8-474a-b20b-cf1c5b4fadbf";

            MunicipalDistrict melbourneCbdByString = MunicipalDistrict.GetById(melbourneCbdStringId);
            MunicipalDistrict melbourneCbdByGuid = MunicipalDistrict.GetById(Guid.Parse(melbourneCbdStringId));

            Assert.True(melbourneCbdByString == melbourneCbdByGuid, "The objects are not equal.");

            List<MunicipalDistrict> melbsMDByString = MunicipalDistrict.ListByMunicipalDistrictId(melbourneMunicipalDistrictId);
            List<MunicipalDistrict> melbsMDByGuid = MunicipalDistrict.ListByMunicipalDistrictId(Guid.Parse(melbourneMunicipalDistrictId));

            Assert.True(melbsMDByString.Count() == melbsMDByGuid.Count(), "Danger Will Robinson!");
            Assert.True(melbsMDByGuid.Any(_ => _.DistrictName == "Melbourne CBD"), "Danger Will Robinson!");

            var supported = RegionalDistrict.List();
            int validSupported = 2;

            Assert.True(supported.Count() >= validSupported, 
                string.Format("Expected {0} but retrieved {1}. Has the number of supported districts changed?", supported.Count(), validSupported));
        }
    }
}
