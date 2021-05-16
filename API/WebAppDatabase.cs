using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public partial class WebAppDatabase
    {
        private readonly string _username;
        private static readonly Dictionary<string, Model.Auth.User> _loginUsers = new Dictionary<string, Model.Auth.User>();

        public static WebAppDatabase Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                throw new SystemException("Username Password combination invalid.");

            var database = new WebAppDatabase(username);

            var user = database.Users.FirstOrDefault(x => x.Username == username);

            if (user == null || !user.Active)
                throw new SystemException("Username Password combination invalid.");

            return database;
        }

        public static WebAppDatabase GetContext(string username, TimeSpan? timeout = null)
        {
            return new WebAppDatabase(username, timeout);
        }

        public WebAppDatabase(string username, TimeSpan? timeout = null) : this()
        {
            if (timeout != null)
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = (int)timeout.Value.TotalSeconds;

            _username = username;
        }

        public Model.Auth.User CurrentUser
        {
            get
            {
                lock (_loginUsers)
                {
                    if (!_loginUsers.ContainsKey(_username))
                    {
                        var user = Users.FirstOrDefault(x => x.Username == _username);
                        _loginUsers.Add(_username, user.GetAuthUser());
                    }

                    var authUser = _loginUsers[_username];

                    if (DateTime.Now - authUser.LastUsed > TimeSpan.FromMinutes(5))
                    {
                        var user = Users.FirstOrDefault(x => x.Username == _username);
                           _loginUsers[_username] = authUser = user.GetAuthUser();
                    }

                    return authUser;
                }
            }
        }

        public override int SaveChanges()
        {
            try
            {
                var validateEntries = (ChangeTracker.Entries()
                    .Where(entry => entry.State == EntityState.Added || entry.State == EntityState.Modified)
                    .Where(entry => entry.Entity is IValidate)).ToArray();

                foreach (var validate in validateEntries.Select(i => i.Entity).OfType<IValidate>())
                {
                    validate.OnSave(this);
                }

                return base.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}
