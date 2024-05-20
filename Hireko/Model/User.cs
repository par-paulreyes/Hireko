namespace Hireko.Model
{
    internal class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UserPass { get; set; }
        public string UserFName { get; set; }
        public string UserLName { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public string UserPhone { get; set; }
        public decimal UserRating { get; set; }
        public string UserType { get; set; }
    }

    internal static class CurrentUser
    {
        public static string Username { get; set; }
        public static int UserId { get; set; }
    }
}


