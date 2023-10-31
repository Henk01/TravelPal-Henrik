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

            //Show users trips in listview
            if (UserManager.signedInUser.GetType() == typeof(User))
            {
                User user = (User)UserManager.signedInUser;


                lstTravels.SelectedIndex = 0;
                lstTravels.ItemsSource = user.Travels;
            }
        }

        //Show details about travel
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            Travel? travel = lstTravels.SelectedItem as Travel;

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
    }
}
