using System.Collections.Generic;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Models;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Services
{
    internal static class TravelManager
    {
        //static List<Travel> travels = new();

        //Add vacation
        internal static Travel CreateTravel(bool allInclusive, Country destination, string city, int travelers, string tripType, List<IPackingListItem> packItems)
        {

            Vacation newVacation = new(allInclusive, city, travelers, destination, packItems);

            return newVacation;

        }

        //Add work trip
        internal static Travel CreateTravel(string meetingDetails, Country destination, string city, int travelers, string tripType, List<IPackingListItem> packItems)
        {

            WorkTrip newWorkTrip = new(meetingDetails, city, travelers, destination, packItems);

            return newWorkTrip;

        }

    }
}
