using System.Windows;

namespace TravePal_Henrik
{
    /// <summary>
    /// Interaction logic for TravelPalWindow.xaml
    /// </summary>
    public partial class TravelPalWindow : Window
    {
        public TravelPalWindow()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new TravelsWindow();
            travelsWindow.Show();
            this.Close();
        }
    }
}
