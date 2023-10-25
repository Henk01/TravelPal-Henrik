using TravePal_Henrik.Enums;

namespace TravePal_Henrik.Models
{
    internal class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(bool allInclusive, string destination, int travelers, Country country) : base(destination, travelers, country)
        {
            AllInclusive = allInclusive;
        }

        //Print travelinfo
        internal override string GetInfo()
        {
            return $"Destination: {Destination}, {Travelers} travelers from {Country}, allinclusive: {AllInclusive}";
        }
    }
}
