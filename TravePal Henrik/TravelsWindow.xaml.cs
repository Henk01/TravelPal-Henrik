using System.Collections.Generic;
using System.Windows;
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

            if (UserManager.signedInUser.Username == "admin")
            {
                btnAddTravel.Visibility = Visibility.Hidden;
            }


            //Show users trips in listview
            if (UserManager.signedInUser.GetType() == typeof(User))
            {
                User user = (User)UserManager.signedInUser;

                lstTravels.ItemsSource = user.Travels;


                lstTravels.SelectedIndex = 0;
            }
            //If user is admin show all trips in listview
            else if (UserManager.signedInUser is Admin)
            {


                List<Travel> allTrips = new();
                allTrips = UserManager.GetAllTrips();
                lstTravels.ItemsSource = allTrips;
            }
        }

        //Show details about travel
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            //If trip is selected open DetailsWindow
            if (lstTravels.SelectedIndex != -1)
            {
                Travel? travel = (Travel)lstTravels.SelectedItem;

                TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(travel);
                travelDetailsWindow.Show();
                this.Close();
            }
            //If no trip is selected show warning
            else
            {
                MessageBox.Show("Pick a trip to show details", "Problem");
            }

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
            Travel travel = lstTravels.SelectedItem as Travel;
            if (UserManager.signedInUser is User)
            {
                ((User)UserManager.signedInUser).Travels.Remove(travel);
                lstTravels.ItemsSource = UserManager.GetAllTrips();
            }
            else if (UserManager.signedInUser is Admin)
            {
                UserManager.AdminRemoveTravel(travel);
                lstTravels.ItemsSource = UserManager.GetAllTrips();
            }


        }
    }
}
