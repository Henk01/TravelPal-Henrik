using System.Windows;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Services;

namespace TravePal_Henrik
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {


            bool userIsAdded = UserManager.AddUser(txtUsername.Text, txtPassword.Password, EuropeanCountry.Sweden);
            if (userIsAdded)
            {
                MessageBox.Show("User Added");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid password or username, Warning");
            }

        }
    }
}
