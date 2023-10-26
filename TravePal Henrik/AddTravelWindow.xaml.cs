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
    }
}
