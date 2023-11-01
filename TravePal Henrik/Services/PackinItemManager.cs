using TravePal_Henrik.Models;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Services
{
    internal static class PackinItemManager
    {
        //Add documents
        internal static IPackingListItem AddPackItem(string name, bool isRequired)
        {
            TravelDocument travelDocument = new(name, isRequired);
            return travelDocument;
        }

        //Add normal items
        internal static IPackingListItem AddPackItem(string name, int amount)
        {
            OtherItem otherItem = new(amount, name);
            return otherItem;
        }
    }
}
