using TravePal_Henrik.Enums;

namespace TravePal_Henrik.Models
{
    internal abstract class Travel
    {
        public string City { get; set; }
        public int Travelers { get; set; }
        public Country Country { get; set; }

        public Travel(string city, int travelers, Country destination)
        {
            City = city;
            Travelers = travelers;
            Country = destination;
        }

        internal virtual string GetInfo()
        {
            return $"Destination: {City}, {Travelers} travelers from {Country}";
        }
    }
}
