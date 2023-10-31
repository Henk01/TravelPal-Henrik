using System.Windows;
using TravePal_Henrik.Models;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        internal Travel ChoosedTravel { get; set; }
        internal TravelDetailsWindow(Travel travel)
        {
            InitializeComponent();
            ChoosedTravel = travel;

            lstTripInfo.Items.Add(ChoosedTravel.GetInfo());
            foreach (IPackingListItem item in ChoosedTravel.PackItems)
            {
                lstPackList.Items.Add(item.GetInfo());
            }
        }

        //Return to travel overview
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            this.Close();
        }
    }
}
