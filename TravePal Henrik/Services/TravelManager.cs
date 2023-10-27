using System.Collections.Generic;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Models;

namespace TravePal_Henrik.Services
{
    internal static class TravelManager
    {
        static List<Travel> travels = new();

        //Add travel
        internal static void AddTravel(bool allInclusive, string meetingDetails, Country destination, string city, int travelers, string tripType)
        {
            if (tripType == "Vacation")
            {
                Vacation newVacation = new(allInclusive, city, travelers, destination);
            }
            else if (tripType == "WorkTrip")
            {
                WorkTrip newWorkTrip = new(meetingDetails, city, travelers, destination);
            }
        }

        //Remove travel
        static internal void RemoveTravel(Travel travel)
        {
            travels.Remove(travel);
        }
    }
}
