using System.Collections.Generic;
using TravePal_Henrik.Enums;
using TravePal_Henrik.Models;
using TravePal_Henrik.Models.Interface;

namespace TravePal_Henrik.Services
{
    internal static class UserManager
    {
        static List<IUser> users = new()
        {
            new Admin("username", "password", EuropeanCountry.Sweden)
        };

        internal static IUser? signedInUser = null;

        internal static bool AddUser(string username, string password, EuropeanCountry country)
        {
            if (ValidateUsername(username))
            {
                User? user = new(username, password, country);
                users.Add(user);
                return true;
            }
            return false;

        }

        internal static void RemoveUser(IUser user)
        {
            users.Remove(user);
        }

        internal static bool SignInUser(string username, string password)
        {
            bool userIsSignedIn = false;
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

        internal static bool UpdateUsername(IUser user, string newUsername)
        {

            if (ValidateUsername(newUsername))
            {
                user.Username = newUsername;
                return true;
            }
            return false;
        }

        private static bool ValidateUsername(string username)
        {
            bool isValid = false;
            if (!string.IsNullOrEmpty(username))
            {
                isValid = true;
            }
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    isValid = false;
                    break;
                }

            }

            return isValid;
        }
    }
}
