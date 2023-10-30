using System.Windows;

namespace TravePal_Henrik
{
    /// <summary>
    /// Interaction logic for PackListWindow.xaml
    /// </summary>
    public partial class PackListWindow : Window
    {
        public PackListWindow()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new AddTravelWindow();
            addTravelWindow.Show();
            this.Close();
        }
    }
}
