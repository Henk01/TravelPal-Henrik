using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Models
{
    internal class TravelDocument : IPackingListItem
    {
        public bool Required { get; set; }
        public string Name { get; set; }


        public TravelDocument(string name, bool required)
        {
            Name = name;
            Required = required;
        }

        public string GetInfo()
        {
            return $"Name:{Name}, required: {Required}";
        }
    }
}
