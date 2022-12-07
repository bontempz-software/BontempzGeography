﻿using BontempzGeography.Models;
using NetTopologySuite.Geometries;

namespace BontempzGeography.DataSource
{
    public class Landmark
    {
        public Guid LandmarkId { get; set; }
        public Guid MunicipalDistrictId { get; set; }
        public string? LandmarkName { get; set; }
        public Point? Location { get; set; }

        public Landmark(string landmarkId, string municipalDistrictId, string landmarkName, double latitude, double longitude)
        {
            LandmarkId = Guid.Parse(landmarkId);
            MunicipalDistrictId = Guid.Parse(municipalDistrictId);
            LandmarkName = landmarkName;
            Location = new GeographicPoint(latitude, longitude).Point;
        }

        public static Landmark GetById(Guid landmarkId)
        {
            return landmarks.Where(_ => _.LandmarkId == landmarkId).First();
        }

        public static List<Landmark> List()
        {
            return landmarks.ToList();
        }

        public static List<Landmark> List(string municipalDistrictId)
        {
            return landmarks.Where(_ => _.MunicipalDistrictId == Guid.Parse(municipalDistrictId)).ToList();
        }

        public static List<Landmark> List(Guid municipalDistrictId)
        {
            return landmarks.Where(_ => _.MunicipalDistrictId == municipalDistrictId).ToList();
        }

        private static List<Landmark> landmarks = new List<Landmark>()
        {
            //new District("{Landmark ID}", "{{Muni Dist ID}", "{Landmark Name}", "{Latitude}", "{Longitude}"),
            // Melbourne CBD
            new Landmark("1901d9b7-7f37-49a9-9694-f5d221e76b78", "3141c61f-8102-4ea9-ab94-369529dbb2af", "Flinders Street Station", -37.8177682, 144.967196),
            new Landmark("e519c3dd-9239-4222-b4fc-9bc6a011b7c1", "3141c61f-8102-4ea9-ab94-369529dbb2af", "Parliament Station", -37.8124539, 144.9733865),
            new Landmark("8652e5f8-53ed-4d99-a601-c5a44dd6573e", "3141c61f-8102-4ea9-ab94-369529dbb2af", "Melbourne Central Station", -37.8098666, 144.9637815),
            new Landmark("50db8f48-b088-403a-810c-edc5c80de247", "3141c61f-8102-4ea9-ab94-369529dbb2af", "Flagstaff Station", -37.8119687, 144.9563089),
            new Landmark("c37105e9-d103-4e92-b881-f17820437f71", "3141c61f-8102-4ea9-ab94-369529dbb2af", "Southern Cross Station", -37.8184123, 144.9536884),
            
            // Richmond Victoria
            new Landmark("55c86875-706c-408f-aff3-fb93e53f98fc", "736a634b-96c8-46a2-ba9f-e40b50aadcd1", "Richmond Station", -37.8245822, 144.998001),
            new Landmark("466b89cd-a1d2-43a9-8d23-4ec714e4dc8d", "736a634b-96c8-46a2-ba9f-e40b50aadcd1", "East Richmond Station", -37.8263486, 144.9972507),
            new Landmark("c8a3aae6-0b07-4e21-9279-9e7d7bc49f35", "736a634b-96c8-46a2-ba9f-e40b50aadcd1", "North Richmond Station", -37.8104, 144.9924),
            new Landmark("bf30aa7f-e506-444a-959b-680f31c23fcc", "736a634b-96c8-46a2-ba9f-e40b50aadcd1", "Burnley Station", -37.8275297, 145.0071636),

            // Chapel Street Precinct Melbourne
            new Landmark("c5aa7c2b-18ab-453c-93a9-89ec0fe8efa1", "ddb28e0d-5e70-4a67-8f7a-30346db29820", "South Yarra Station", -37.8389876, 144.9922103),
            new Landmark("0a571af3-ba13-4a8d-9b92-856706dc48da", "ddb28e0d-5e70-4a67-8f7a-30346db29820", "Prahran Station", -37.8495187, 144.9898821),
            new Landmark("ebeae039-4838-407f-97d3-10ddecb73fd6", "ddb28e0d-5e70-4a67-8f7a-30346db29820", "Windsor Station", -37.8563445, 144.9924383),

            // Glen Huntly Road Elsternwick Victoria
            new Landmark("b1bfa188-e5bf-4c4c-bdb0-82caa21e4140", "9f865fce-bb67-47a4-93b8-ac1be041f79a", "Elsternwick Station", -37.8843019, 145.0001201),

            // St Kilda Victoria
            new Landmark("", "b6a3839a-02e6-440c-93b0-52db3c530f8f", "Acland Street / Barkley Street", -37.8694453, 144.9805555),
            new Landmark("", "b6a3839a-02e6-440c-93b0-52db3c530f8f", "The Esplanade", -37.8649231, 144.9726688),
            new Landmark("", "b6a3839a-02e6-440c-93b0-52db3c530f8f", "St Kilda Station / Fitzroy Street", -37.8593499, 144.9776148),
        };
    }
}
