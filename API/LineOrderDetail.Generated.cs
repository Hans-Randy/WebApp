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
    
    public partial class LineOrderDetail : IEntity
    {
    	private WebAppDatabase _db;
    
        [JsonIgnore]
    	public WebAppDatabase Database 
    	{ 
    		get
    		{
    			if (_db == null)
    				throw new NullReferenceException(string.Format("[Database] property null for LineOrderDetail [ID:{0}]", ID));
    			return _db;
    		}
    		set
    		{
    			_db = value;
    		}
    	}
    
        public LineOrderDetail(WebAppDatabase database) : this()
        {
            Database = database;
        }
    	partial void OnCreated();
    
        public LineOrderDetail()
        {
            DateCreated = DateTime.Now;
    		OnCreated();
        }
    
        public int ID { get; set; }
        public string OrderNo { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
