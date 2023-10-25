using TravePal_Henrik.Enums;

namespace TravePal_Henrik.Models.Interface
{
    internal interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public EUCountry Location { get; set; }



    }
}
