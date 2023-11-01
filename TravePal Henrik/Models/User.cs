using System.Collections.Generic;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Models
{
    internal class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Country Location { get; set; }

        //Add travels to new users
        public List<Travel> Travels { get; set; } = new();

        public User(string username, string password, Country country)
        {
            Username = username;
            Password = password;
            Location = country;
        }


    }


}
