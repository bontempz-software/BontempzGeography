using BontempzGeography.DataSource;

namespace BontempzGeography.Tests
{
    public class DistrictListsFiltered
    {
        [Fact(DisplayName = "Validate Melbourne CBD Venues")]
        public void ValidateMelbourneCbdVenues()
        {
            string melbourneCbdStringId = "e5407fb4-6027-4b5d-aa78-d89316fd2721";
            string melbourneMunicipalDistrictId = "9c967a90-32e8-474a-b20b-cf1c5b4fadbf";

            MunicipalDistrict melbourneCbdByString = MunicipalDistrict.GetById(melbourneCbdStringId);
            MunicipalDistrict melbourneCbdByGuid = MunicipalDistrict.GetById(Guid.Parse(melbourneCbdStringId));

            Assert.True(melbourneCbdByString == melbourneCbdByGuid, "The objects are not equal.");

            List<MunicipalDistrict> melbsMDByString = MunicipalDistrict.ListByMunicipalDistrictId(melbourneMunicipalDistrictId);
            List<MunicipalDistrict> melbsMDByGuid = MunicipalDistrict.ListByMunicipalDistrictId(Guid.Parse(melbourneMunicipalDistrictId));

            Assert.True(melbsMDByString.Count() == melbsMDByGuid.Count(), "Danger Will Robinson!");
            Assert.True(melbsMDByGuid.Any(_ => _.DistrictName == "Melbourne CBD"), "Danger Will Robinson!");

            Dictionary<string, string> supported = RegionalDistrict.Supported();
            int validSupported = 2;

            Assert.True(supported.Count() == validSupported, 
                string.Format("Expected {0} but retrieved {1}. Has the number of supported districts changed?", supported.Count(), validSupported));
        }
    }
}
