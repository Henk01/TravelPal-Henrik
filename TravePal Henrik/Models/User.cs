using TravePal_Henrik.Enums;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Models
{
    internal class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public EuropeanCountry Location { get; set; }


        public User(string username, string password, EuropeanCountry country)
        {
            Username = username;
            Password = password;
            Location = country;
        }


    }


}
