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
    
    public partial class Order : IEntity
    {
    	private WebAppDatabase _db;
    
        [JsonIgnore]
    	public WebAppDatabase Database 
    	{ 
    		get
    		{
    			if (_db == null)
    				throw new NullReferenceException(string.Format("[Database] property null for Order [ID:{0}]", ID));
    			return _db;
    		}
    		set
    		{
    			_db = value;
    		}
    	}
    
        public Order(WebAppDatabase database) : this()
        {
            Database = database;
        }
    	partial void OnCreated();
    
        public Order()
        {
            this.LineItems = new HashSet<LineItem>();
    		OnCreated();
        }
    
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public int UserID { get; set; }
        public System.DateTime DateCreated { get; set; }
    
    
       [JsonIgnore] public virtual ICollection<LineItem> LineItems { get; set; }
       [JsonIgnore] public virtual User User { get; set; }
    }
}