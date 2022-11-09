using System.ComponentModel.DataAnnotations;

namespace BontempzGeography.Enums.UnitsOfMeasurement
{
    public enum Distance
    {
        [Display(Name = "Foot / Feet")]
        Foot = 1,

        [Display(Name = "Metre(s)")]
        Metre = 10,

        [Display(Name = "Kilometre(s)")]
        Kilometre = 50,

        [Display(Name = "Mile(s)")]
        Mile = 60
    }
}
