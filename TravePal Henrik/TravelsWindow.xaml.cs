using System.Windows;
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

            lblUsername.Content = UserManager.signedInUser.Username;
        }

        //Show details about travel
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow();
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

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow();
            addTravelWindow.Show();
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            TravelPalWindow travelPalWindow = new TravelPalWindow();
            travelPalWindow.Show();
            this.Close();
        }
    }
}
