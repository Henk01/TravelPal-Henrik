using TravePal_Henrik.Enums;

namespace TravePal_Henrik.Models
{
    internal class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string meetingDetails, string destination, int travelers, Country country) : base(destination, travelers, country)
        {
            MeetingDetails = meetingDetails;
        }

        //Print travelinfo
        internal override string GetInfo()
        {
            return $"Destination: {Destination}, {Travelers} travelers from {Country}, Meetingdetails: {MeetingDetails}";
        }
    }
}
