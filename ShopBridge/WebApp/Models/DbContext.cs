using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;


namespace WebApp.Models
{
    public class InventoryContext: DbContext
    {
       
        public InventoryContext(): base()
        {

        }
        #region Required
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer<InventoryContext>(null);

        }
        #endregion
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        
    }
}