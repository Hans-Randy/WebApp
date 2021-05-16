using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public partial class WebAppDatabase
    {
        public static WebAppDatabase GetContext(string username, TimeSpan? timeout = null)
        {
            return new WebAppDatabase(username, timeout);
        }

        public WebAppDatabase(string username, TimeSpan? timeout = null) : this()
        {
            if (timeout != null)
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = (int)timeout.Value.TotalSeconds;

            _username = username;

            if (DownForMaintenance)
            {
                if (!CurrentUser.MaintenanceUser)
                    throw new Exception("The system is currently unavaialble due to scheduled maintenance");
            }
        }

        public static string ConnectionString
        {
            get
            {
                using (var database = new WebAppDatabase())
                {
                    return database.Database.Connection.ConnectionString;
                }
            }
        }
    }
}
