using System.Collections.Generic;
using TravePal_Henrik.Models;

namespace TravePal_Henrik.Services
{
    internal static class TravelManager
    {
        static List<Travel> travels = new();

        //Add travel
        static internal void AddTravel(Travel travel)
        {
            travels.Add(travel);
        }

        //Remove travel
        static internal void RemoveTravel(Travel travel)
        {
            travels.Remove(travel);
        }
    }
}
