using TravePal_Henrik.Enums;

namespace TravePal_Henrik.Models
{
    internal abstract class Travel
    {
        public string Destination { get; set; }
        public int Travelers { get; set; }
        public Country Country { get; set; }

        public Travel(string destination, int travelers, Country country)
        {
            Destination = destination;
            Travelers = travelers;
            Country = country;
        }

        internal virtual string GetInfo()
        {
            return $"Destination: {Destination}, {Travelers} travelers from {Country}";
        }
    }
}
