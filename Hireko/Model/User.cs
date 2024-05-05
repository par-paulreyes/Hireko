using System;

namespace Hireko.Database
{
    public static class User
    {
        public static string UserId { get; set; }
        public static string Username { get; set; }
        public static string CurrentUser { get; set; }
        public static string UserPass { get; set; }
        public static string UserFName { get; set; }
        public static string UserLName { get; set; }
        public static string UserEmail { get; set; }
        public static string UserAddress { get; set; }
        public static string UserPhone { get; set; }
        public static string UserRating { get; set; }
        public static string UserType { get; set; }

        public static string GetCurrentUser()
        {
            return CurrentUser;
        }

        public static string GetUsername()
        {
            return Username;
        }

        public static string GetUserId()
        {
            return UserId;
        }

        public static string GetUserPass()
        {
            return UserPass;
        }

        public static string GetUserFName()
        {
            return UserFName;
        }

        public static string GetUserLName()
        {
            return UserLName;
        }

        public static string GetUserEmail()
        {
            return UserEmail;
        }

        public static string GetUserAddress()
        {
            return UserAddress;
        }

        public static string GetUserPhone()
        {
            return UserPhone;
        }

        public static string GetUserRating()
        {
            return UserRating;
        }

        public static string GetUserType()
        {
            return UserType;
        }
    }
}
