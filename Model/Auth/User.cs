using System;
using static Model.Enumeration;

namespace Model.Auth
{
    public class User
    {
        public DateTime LastUsed { get; set; }
        public int UserID { get; set; }
        public int UserTypeID { get; set; }
        public UserTypeEnum UserType => (UserTypeEnum)UserTypeID;
        public string Username { get; set; }
        public bool IsStaff { get; set; }
    }
}
