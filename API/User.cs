using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using Model;

namespace API
{
    public partial class User :IValidate
    {
        public void OnSave(WebAppDatabase database)
        {
            var errors = new StringBuilder();

            errors.AppendError(database.Users.Any(x => x.Username == Username && x.ID != ID), $"The username [{Username}] is already in use.");

            errors.AppendError(string.IsNullOrWhiteSpace(Username), "User requires a username");
            errors.AppendError(string.IsNullOrWhiteSpace(Password), "User requires a password");
            errors.AppendError(Password.IsRegexMatch("^(?=.*[0-9]).{1,}$"), "Requires 1 number.");
            errors.AppendError(Password.IsRegexMatch("^(?=.*[a-z]).{1,}$"), "Requires 1 lower case letter.");
            errors.AppendError(Password.IsRegexMatch("^(?=.*[A-Z]).{1,}$"), "Requires 1 upper case letter.");
            errors.AppendError(Password.IsRegexMatch("[^a-zA-Z0-9 ]"), "Requires 1 special character.");
            errors.AppendError(Password.Length < 8, "Minimun length of 8.");

            errors.AppendError(UserTypeID == 0, "User requires a type");

            errors.ErrorCheck();
        }

        public Model.Auth.User GetAuthUser()
        {
            return new Model.Auth.User
            {
                Username = Username,
                UserID = ID,
                UserTypeID = UserTypeID,
                LastUsed = DateTime.Now,
                IsStaff = UserType.IsStaff,
            };
        }
    }
}
