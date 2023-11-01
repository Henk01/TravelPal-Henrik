using System.Collections.Generic;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Models
{
    internal abstract class Travel
    {
        public string City { get; set; }
        public int Travelers { get; set; }
        public Country Country { get; set; }

        public List<IPackingListItem> PackItems { get; set; }

        public Travel(string city, int travelers, Country destination, List<IPackingListItem> packItems)
        {
            City = city;
            Travelers = travelers;
            Country = destination;
            PackItems = packItems;
        }
        //String to override in work trip/vacation
        internal virtual string GetInfo()
        {
            return $"Destination: {City}, {Travelers} travelers from {Country}";
        }
    }
}
