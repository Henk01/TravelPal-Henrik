using System.Windows;
using TravePal_Henrik.Services;

namespace TravePal_Henrik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool userLoggedIn = UserManager.SignInUser(txtUsername.Text, txtPassword.Password);
            if (!userLoggedIn)
            {
                MessageBox.Show("Wrong username or password, error");
            }
            else
            {
                TravelsWindow travelsWindow = new TravelsWindow();
                travelsWindow.Show();
                this.Close();
            }
        }
    }
}
