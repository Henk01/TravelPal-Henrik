using TravePal_Henrik.Enums;

namespace TravePal_Henrik.Models
{
    internal class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(bool allInclusive, string city, int travelers, Country destination) : base(city, travelers, destination)
        {
            AllInclusive = allInclusive;
        }

        //Print travelinfo
        internal override string GetInfo()
        {
            return $"Destination: {City}, {Travelers} travelers, allinclusive: {AllInclusive}";
        }
    }
}
