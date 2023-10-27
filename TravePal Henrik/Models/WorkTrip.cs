using TravePal_Henrik.Enums;

namespace TravePal_Henrik.Models
{
    internal class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string meetingDetails, string city, int travelers, Country destination) : base(city, travelers, destination)
        {
            MeetingDetails = meetingDetails;
        }

        //Print travelinfo
        internal override string GetInfo()
        {
            return $"Destination: {City}, {Travelers} travelers, Meetingdetails: {MeetingDetails}";
        }
    }
}
