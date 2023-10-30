using System;
using System.Windows;
using TravePal_Henrik.Enums;

namespace TravePal_Henrik
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow()
        {
            InitializeComponent();

            //Add type of trip to combobox
            cmbTripType.Items.Add("Work trip");
            cmbTripType.Items.Add("Vacation");

            //Add number of travelers to combobox
            for (int i = 1; i <= 10; i++)
            {
                cmbTravelers.Items.Add(i.ToString());
            }

            //Amount of items
            for (int i = 1; i <= 10; i++)
            {
                cmbAmount.Items.Add(i.ToString());
            }

            //Add destination country to combobox
            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                cmbCountry.Items.Add(country);
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            this.Close();
        }

        private void cmbTripType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //If Worktrip show meetingdetails
            if (cmbTripType.SelectedItem == "Work trip")
            {
                lblMeeting.Visibility = Visibility.Visible;
                txtMeetingDetails.Visibility = Visibility.Visible;
                checkAllInc.Visibility = Visibility.Hidden;
            }
            //If Vacation show all inclusive checkbox
            else if (cmbTripType.SelectedItem == "Vacation")
            {
                checkAllInc.Visibility = Visibility.Visible;
                lblMeeting.Visibility = Visibility.Hidden;
                txtMeetingDetails.Visibility = Visibility.Hidden;
            }

        }

        private void btnPackList_Click(object sender, RoutedEventArgs e)
        {
            PackListWindow packListWindow = new PackListWindow();
            packListWindow.Show();
            this.Close();
        }

        private void checkDoc_Checked(object sender, RoutedEventArgs e)
        {
            lblAmount.Visibility = Visibility.Hidden;
            cmbAmount.Visibility = Visibility.Hidden;
            checkRequired.Visibility = Visibility.Visible;
        }

        //private void btnAdd_Click(object sender, RoutedEventArgs e)
        //{
        //    bool isTripAdded = TravelManager.AddTravel();
        //}
    }
}
