using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Models
{
    internal class OtherItem : IPackingListItem
    {


        public int Quantity { get; set; }
        public string Name { get; set; }

        public OtherItem(int quantity, string name)
        {
            Quantity = quantity;
            Name = name;
        }

        public string GetInfo()
        {
            return $"Quantity: {Quantity}, item: {Name}";

        }
    }
}
