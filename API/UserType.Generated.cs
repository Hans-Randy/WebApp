//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace API
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class UserType : IEntity
    {
    	private WebAppDatabase _db;
    
        [JsonIgnore]
    	public WebAppDatabase Database 
    	{ 
    		get
    		{
    			if (_db == null)
    				throw new NullReferenceException(string.Format("[Database] property null for UserType [ID:{0}]", ID));
    			return _db;
    		}
    		set
    		{
    			_db = value;
    		}
    	}
    
        public UserType(WebAppDatabase database) : this()
        {
            Database = database;
        }
    	partial void OnCreated();
    
        public UserType()
        {
            
            this.Users = new HashSet<User>();
    		OnCreated();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsStaff { get; set; }
    
    
       [JsonIgnore] public virtual ICollection<User> Users { get; set; }
    }
}
