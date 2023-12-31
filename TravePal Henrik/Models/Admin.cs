﻿using System.Collections.Generic;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Models
{
    internal class Admin : IUser
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }

        public List<Travel> Travels { get; set; }
        //Admin Ctor
        public Admin(string username, string password, Country country)
        {
            Username = username;
            Password = password;
            Location = country;

        }
    }
}
