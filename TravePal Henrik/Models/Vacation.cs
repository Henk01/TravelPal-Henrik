using System.Collections.Generic;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Models
{
    internal class Vacation : Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(bool allInclusive, string city, int travelers, Country destination, List<IPackingListItem> packItems) : base(city, travelers, destination, packItems)
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
