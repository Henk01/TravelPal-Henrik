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
    }
}
