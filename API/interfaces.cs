using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Newtonsoft.Json;

namespace API
{

    public interface IEntity
    {
        WebAppDatabase Database { get; set; }
        int ID { get; }
    }

    public interface IOnLoad
    {
        void OnLoad();
    }

    public interface IValidate
    {
        void OnSave(WebAppDatabase database);
    }

    public static class InterfaceHelper
    {
        public static T Get<T>(this WebAppDatabase db, int? id) where T : class, IEntity
        {
            return db.Set<T>().Get(db, id);
        }

        public static T Get<T>(this DbSet<T> set, Enum id) where T : class, IEntity
        {
            return set.Get(Convert.ToInt32(id));
        }

        public static T Get<T>(this DbSet<T> set, WebAppDatabase database, Enum id) where T : class, IEntity
        {
            return set.Get(database, Convert.ToInt32(id));
        }

        public static T Get<T>(this IEnumerable<T> set, Enum id) where T : class, IEntity
        {
            return set.Get(Convert.ToInt32(id));
        }

        public static T Get<T>(this IEnumerable<T> set, WebAppDatabase database, Enum id) where T : class, IEntity
        {
            return set.Get(database, Convert.ToInt32(id));
        }

        public static T Get<T>(this DbSet<T> set, int? id) where T : class, IEntity
        {
            return id == null ? null : set.FirstOrDefault(x => x.ID == id);
        }

        public static T Get<T>(this IEnumerable<T> list, int? id) where T : class, IEntity
        {
            return id == null ? null : list.FirstOrDefault(x => x.ID == id);
        }

        public static T Get<T>(this DbSet<T> set, WebAppDatabase database, int? id) where T : class, IEntity
        {
            var result = set.Get(id);
            if (result != null)
                result.Database = database;
            var onLoad = result as IOnLoad;
            if (onLoad != null)
                onLoad.OnLoad();
            return result;
        }

        public static T Get<T>(this IEnumerable<T> list, WebAppDatabase database, int? id) where T : class, IEntity
        {
            var result = list.Get(id);
            if (result != null)
                result.Database = database;
            var onLoad = result as IOnLoad;
            if (onLoad != null)
                onLoad.OnLoad();
            return result;
        }

        public static void Reload(this IEntity item)
        {
            item.Database.Entry(item).Reload();
        }

        public static void Remove<T>(this DbSet<T> set, IEnumerable<T> items) where T : class, IEntity
        {
            foreach (var o in items.ToArray())
                set.Remove(o);
        }

        public static string GetJson(this IEntity item)
        {
            return JsonConvert.SerializeObject(item, Formatting.Indented);
        }
    }
}
