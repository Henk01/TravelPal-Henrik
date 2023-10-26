using System.Windows;

namespace TravePal_Henrik
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        public TravelDetailsWindow()
        {
            InitializeComponent();
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
