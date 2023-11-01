using System;
using System.Collections.Generic;
using System.Windows;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Models;
using TravePal_Henrik.Models.Interface;
using TravePal_Henrik.Services;

namespace TravePal_Henrik
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {

        public List<IPackingListItem> PackingItems { get; set; } = new List<IPackingListItem>();
        public AddTravelWindow()
        {
            InitializeComponent();

            //Add type of trip to combobox
            cmbTripType.Items.Add("Work trip");
            cmbTripType.Items.Add("Vacation");

            //Put items in packlist
            foreach (var item in PackingItems)
            {
                lstPackList.Items.Add(item);
            }

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

        //Go back to TravelWindow
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            this.Close();
        }

        //Choose type of trip
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


        //Pick if its travel document
        private void checkDoc_Click(object sender, RoutedEventArgs e)
        {
            //If its travel document show required
            if ((bool)checkDoc.IsChecked!)
            {
                lblAmount.Visibility = Visibility.Hidden;
                cmbAmount.Visibility = Visibility.Hidden;
                checkRequired.Visibility = Visibility.Visible;
            }
            //If its not traveldocument show amount of items to add
            else
            {
                lblAmount.Visibility = Visibility.Visible;
                cmbAmount.Visibility = Visibility.Visible;
                checkRequired.Visibility = Visibility.Hidden;
            }


        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            bool City = txtCity.Text.Trim().Length > 0;
            bool Travelers = cmbTravelers.SelectedIndex != -1;
            bool Country = cmbCountry.SelectedIndex != -1;
            bool TripType = cmbTripType.SelectedIndex != -1;
            bool MeetingDet = string.IsNullOrWhiteSpace(txtMeetingDetails.Text);

            if (City && Travelers && Country && TripType)
            {
                if (cmbTripType.SelectedItem == "Work trip" && string.IsNullOrWhiteSpace(txtMeetingDetails.Text))
                {
                    MessageBox.Show("Please put in meeting details", "Error");
                    return;
                }
                Country selectedCountry = (Country)cmbCountry.SelectedItem;
                if (cmbTripType.SelectedItem == "Vacation")
                {
                    Travel travel = TravelManager.CreateTravel((bool)checkAllInc.IsChecked, (Country)cmbCountry.SelectedItem, txtCity.Text, int.Parse(cmbTravelers.SelectedItem.ToString()), (string)cmbTripType.SelectedItem, new List<IPackingListItem>(PackingItems));
                    User user = (User)UserManager.signedInUser;
                    user.Travels.Add(travel);
                    PackingItems.Clear();

                }
                if (cmbTripType.SelectedItem == "Work trip")
                {
                    Travel travel = TravelManager.CreateTravel(txtMeetingDetails.Text, (Country)cmbCountry.SelectedItem, txtCity.Text, int.Parse(cmbTravelers.SelectedItem.ToString()), (string)cmbTripType.SelectedItem, new List<IPackingListItem>(PackingItems));
                    User user = (User)UserManager.signedInUser;
                    user.Travels.Add(travel);
                    PackingItems.Clear();
                }

                TravelsWindow travelsWindow = new TravelsWindow();
                travelsWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please put in all info", "Error");

            }

        }

        //Add item to packlist
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            //If there is no item show warning
            if (string.IsNullOrWhiteSpace(txtPackList.Text))
            {
                MessageBox.Show("Add item in list", "Error");
            }
            //Add Traveldocument to list
            if ((bool)checkDoc.IsChecked)
            {
                IPackingListItem item = PackinItemManager.AddPackItem(txtPackList.Text, (bool)checkRequired.IsChecked);
                PackingItems.Add(item);
                lstPackList.Items.Add(item);
                txtPackList.Clear();
                checkRequired.IsChecked = false;
            }
            //Add otheritem to list
            else
            {
                IPackingListItem item = PackinItemManager.AddPackItem(txtPackList.Text, int.Parse(cmbAmount.SelectedItem.ToString()));
                PackingItems.Add(item);
                lstPackList.Items.Add(item);
                txtPackList.Clear();
                cmbAmount.SelectedIndex = -1;
            }


        }
    }
}
