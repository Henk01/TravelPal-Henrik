using System;
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

            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                comboCountry.Items.Add(country);
            }
        }

        //Create user
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //Create user if input is valid
            bool userIsAdded = UserManager.AddUser(txtUsername.Text, txtPassword.Password, Country.Sweden);
            if (userIsAdded)
            {
                MessageBox.Show("User Added");
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            //Try again if input is invalid
            else
            {
                MessageBox.Show("Invalid password or username, Warning");
            }

        }
    }
}
