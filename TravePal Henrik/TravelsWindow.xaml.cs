using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravePal_Henrik.Models;
using TravePal_Henrik.Services;

namespace TravePal_Henrik
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();

            //Change label to logged in user username
            lblUsername.Content = UserManager.signedInUser.Username;

            //Show users trips in listview
            if (UserManager.signedInUser.GetType() == typeof(User))
            {
                User user = (User)UserManager.signedInUser;

                foreach (Travel travel in ((User)UserManager.signedInUser).Travels)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = travel;
                    item.Content = new { Country = travel.Country };

                    lstTravels.Items.Add(item);
                }

                lstTravels.SelectedIndex = 0;
            }
            else if (UserManager.signedInUser is Admin)
            {

                List<Travel> allTrips = new();
                allTrips = UserManager.GetAllTrips();

                foreach (Travel travel in allTrips)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = travel;
                    item.Content = new { Country = travel.Country };

                    lstTravels.Items.Add(item);
                }
            }
        }

        //Show details about travel
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            Travel? travel = (Travel)((ListViewItem)lstTravels.SelectedItem).Tag;

            TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(travel);
            travelDetailsWindow.Show();
            this.Close();
        }

        //Log out user
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        //Add trip to list
        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow();
            addTravelWindow.Show();
            this.Close();
        }

        //Show information about TravelPal
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            TravelPalWindow travelPalWindow = new TravelPalWindow();
            travelPalWindow.Show();
            this.Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //TravelManager.RemoveTravel();
        }
    }
}
