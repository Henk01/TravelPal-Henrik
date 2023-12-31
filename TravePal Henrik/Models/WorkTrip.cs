﻿using System.Collections.Generic;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Models
{
    internal class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string meetingDetails, string city, int travelers, Country destination, List<IPackingListItem> packItems) : base(city, travelers, destination, packItems)
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
