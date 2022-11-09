using BontempzGeography.Models;
using NetTopologySuite.Geometries;

namespace BontempzGeography.DataSource
{
    public class District
    {
        public Guid Id { get; set; }
        public Guid MunicipalDistrictId { get; set; }
        public string? Name { get; set; }
        public Polygon Bounds { get; set; }
        public string? MunicipalDistrict { get; set; }
        public string? StateCode { get; set; }
        public string? CountryCode { get; set; }

        public District(string id, string municipalDistrictId, string countryCode, string name, string municipalDistrict, string stateCode, string bounds)
        {
            Id = Guid.Parse(id);
            MunicipalDistrictId = Guid.Parse(municipalDistrictId);
            CountryCode = countryCode;
            Name = name;
            MunicipalDistrict = municipalDistrict;
            StateCode = stateCode;
            Bounds = new GeographicArea(bounds).Area;
        }
    }

    public static class RegionalDistricts
    {
        public static List<District> List()
        {
            return municipalDistrictList;
        }

        public static List<District> List(string municipalDistrict)
        {
            return municipalDistrictList.Where(_ => _.MunicipalDistrict == municipalDistrict).ToList();
        }

        public static District GetById(string id)
        {
            return GetById(Guid.Parse(id));
        }

        public static District GetById(Guid id)
        {
            return municipalDistrictList.First(_ => _.Id == id);
        }

        public static List<District> ListByMunicipalDistrictId(string municipalDistrictId)
        {
            return ListByMunicipalDistrictId(Guid.Parse(municipalDistrictId));
        }

        public static List<District> ListByMunicipalDistrictId(Guid municipalDistrictId)
        {
            return municipalDistrictList.Where(_ => _.MunicipalDistrictId == municipalDistrictId).ToList();
        }

        public static Dictionary<string, string> SupportedMunicipalDistricts()
        {
            return new Dictionary<string, string>()
        {
            { "9c967a90-32e8-474a-b20b-cf1c5b4fadbf", "Melbourne Victoria Australia" },
            { "fbfbc96e-ea8c-4618-84e4-fc013446d83f", "Wilsons Promontory Victoria Australia" }
        };
        }

        private static List<District> municipalDistrictList = new List<District>()
        {
            //new District("", "", "AU", "", "Melbourne", "VIC", ""),
            new District("e5407fb4-6027-4b5d-aa78-d89316fd2721", "9c967a90-32e8-474a-b20b-cf1c5b4fadbf", "AU", "Brunswick Street", "Melbourne", "VIC", "144.9758005 -37.7930328, 144.9731398 -37.8081226, 144.9913359 -37.8099874, 144.9939537 -37.7950676, 144.9939537 -37.7950676, 144.9758005 -37.7930328"),
            new District("ddb28e0d-5e70-4a67-8f7a-30346db29820", "9c967a90-32e8-474a-b20b-cf1c5b4fadbf", "AU", "Chapel Street Precinct", "Melbourne", "VIC", "144.993782 -37.8336833, 144.9912071 -37.8330054, 144.9862289 -37.8564568, 144.9862289 -37.8564568, 144.9957132 -37.8582526, 144.9957132 -37.8582526, 145.0007772 -37.8339545, 145.0007772 -37.8339545, 144.9966574 -37.8345646, 144.993782 -37.8336833"),
            new District("33ffb184-4f28-472c-8ac8-3df787ea05d0", "9c967a90-32e8-474a-b20b-cf1c5b4fadbf", "AU", "Docklands", "Melbourne", "VIC", "144.9330139 -37.8172766, 144.9389791 -37.8203277, 144.9453306 -37.8222939, 144.9532700 -37.8199209, 144.9492359 -37.8139881, 144.9477768 -37.8143610, 144.9454165 -37.8122929, 144.9431419 -37.8128693, 144.9395800 -37.8109367, 144.9347305 -37.8099196, 144.9330139 -37.8172766"),
            new District("9f865fce-bb67-47a4-93b8-ac1be041f79a", "9c967a90-32e8-474a-b20b-cf1c5b4fadbf", "AU", "Glen Huntly Road Elsternwick (West)", "Melbourne", "VIC", "144.9959922 -37.8828475, 144.996078 -37.8843887, 145.0016999 -37.8859129, 145.0154972 -37.8868443, 145.0157118 -37.8854726, 144.9959922 -37.8828475"),
            new District("3141c61f-8102-4ea9-ab94-369529dbb2af", "9c967a90-32e8-474a-b20b-cf1c5b4fadbf", "AU", "Melbourne CBD", "Melbourne", "VIC", "144.9498796 -37.8131744, 144.9554586 -37.8233109, 144.9712086 -37.8190395, 144.9757576 -37.8160223, 144.9714661 -37.8071054, 144.9714661 -37.8071054, 144.9498796 -37.8131744, 144.9498796 -37.8131744"),
            new District("736a634b-96c8-46a2-ba9f-e40b50aadcd1", "9c967a90-32e8-474a-b20b-cf1c5b4fadbf", "AU", "Richmond", "Melbourne", "VIC", "144.9915504 -37.8089024, 144.9879456 -37.8299548, 144.9916363 -37.8331071, 144.9949408 -37.8340223, 144.9981594 -37.8340900, 144.9995756 -37.8274126, 145.0079441 -37.8288024, 145.0106907 -37.8111062, 144.9915504 -37.8089024"),
            new District("b6a3839a-02e6-440c-93b0-52db3c530f8f", "9c967a90-32e8-474a-b20b-cf1c5b4fadbf", "AU", "St Kilda", "Melbourne", "VIC", "144.9828172 -37.8556266, 144.9676466 -37.8638431, 144.9761438 -37.8722788, 144.9870658 -37.8681966, 144.9828172 -37.8556266"),
            new District("39c21bc3-0351-4fa5-8c1d-5a47f068c9aa", "fbfbc96e-ea8c-4618-84e4-fc013446d83f", "AU", "Wilsons Promontory", "Gippsland", "VIC", "146.0440063 -38.9177500, 146.2294006 -39.1907552, 146.5850830 -39.1801107, 146.4848328 -38.7797814, 146.3310242 -38.7465863, 146.0440063 -38.9177500")
        };

    }
}