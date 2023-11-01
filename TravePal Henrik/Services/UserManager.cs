using System.Collections.Generic;
using System.Linq;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Models;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Services
{
    internal static class UserManager
    {
        static List<IUser> users = new()
        {
            //Premade admin account
            new Admin("admin", "password", Country.Sweden),
            //Premade user account
            new User("user", "password", Country.Sweden)
            {
                //Give user 2 trips
                Travels = new List<Travel>()
                {
                    new Vacation(true, "London", 4, Country.United_Kingdom, new List<IPackingListItem> { new OtherItem(2, "Phone")}),
                    new WorkTrip("Sell house to Bill", "Kampala", 2, Country.Uganda, new List<IPackingListItem> { new OtherItem(2, "Phone"), new TravelDocument("Passport", true)}),
                }
            }
        };

        internal static IUser? signedInUser = null;

        //Create user
        internal static bool AddUser(string username, string password, Country country)
        {
            //If valid username add user to list
            if (ValidateUsername(username))
            {
                User? user = new(username, password, country);
                users.Add(user);
                return true;
            }
            return false;

        }

        //Remove user
        internal static void RemoveUser(IUser user)
        {
            users.Remove(user);
        }

        //Login user
        internal static bool SignInUser(string username, string password)
        {
            bool userIsSignedIn = false;
            //Log in user if input matches user in list
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    signedInUser = user;
                    userIsSignedIn = true;
                    break;
                }
            }
            return userIsSignedIn;
        }

        //Change username
        internal static bool UpdateUsername(IUser user, string newUsername)
        {

            if (ValidateUsername(newUsername))
            {
                user.Username = newUsername;
                return true;
            }
            return false;
        }

        public static void AdminRemoveTravel(Travel travelToRemove)
        {
            foreach (var user in users.OfType<User>())
            {
                var travel = user.Travels.FirstOrDefault(t => t == travelToRemove);
                if (travel != null)
                {
                    user.Travels.Remove(travel);
                    return;
                }
            }
        }

        public static List<Travel> GetAllTrips()
        {
            List<Travel> allTravels = new();

            foreach (var user in users)
            {
                if (user is User)
                {
                    allTravels.AddRange(((User)user).Travels);
                }
            }
            return allTravels;
        }

        //Check if username is available
        private static bool ValidateUsername(string username)
        {
            bool isValid = false;

            //Check if textbox is empty
            if (!string.IsNullOrWhiteSpace(username))
            {
                isValid = true;
            }

            //Check if username already exists
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    isValid = false;
                    break;
                }

            }
            //If username doesnt exist return false
            return isValid;
        }
    }
}
