namespace BontempzGeography.DataSource
{
    public class RegionalDistrict
    {
        public Guid RegionalDistrictId { get; set; }
        public string? DistrictName { get; set; }
        public string? CountryCode { get; set; }
        public string? TimeZoneId { get; set; }
        public bool Supported { get; set; }

        public RegionalDistrict(string regionalDistrictId, string districtName, string countryCode, string timeZoneId, bool supported)
        {
            RegionalDistrictId = Guid.Parse(regionalDistrictId);
            DistrictName = districtName;
            CountryCode = countryCode;
            TimeZoneId = timeZoneId;
            Supported = supported;
        }

        public static List<RegionalDistrict> List(bool activeOnly = true)
        {
            if (activeOnly)
            {
                regionalDistrictList.Where(_ => _.Supported == true).ToList();
            }

            return regionalDistrictList;
        }

        public string GetTimeZoneId(Guid regionalDistrictId)
        {
            return regionalDistrictList.First(_ => _.RegionalDistrictId == regionalDistrictId).TimeZoneId;
        }

        private static List<RegionalDistrict> regionalDistrictList = new List<RegionalDistrict>()
        {
            new RegionalDistrict("9c967a90-32e8-474a-b20b-cf1c5b4fadbf", "Melbourne - VIC", "AU", "AUS Eastern Standard Time", true),
            new RegionalDistrict("b0b29b5e-906c-4116-a8c7-0025172c1412", "Sydney - NSW", "AU", "AUS Eastern Standard Time", false)
        };
    }
}