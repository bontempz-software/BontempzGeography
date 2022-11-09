namespace BontempzGeography.Structs
{
    public struct State
    {
        public State(string countryCode, string abbreviation, string name)
        {
            CountryCode = countryCode;
            Abbreviation = abbreviation;
            Name = name;
        }

        public string CountryCode { get; set; }
        public string Abbreviation { get; set; }
        public string Name { get; set; }
    }
}