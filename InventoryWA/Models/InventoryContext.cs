using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.Entity;
using System.Data.Entity;
using InventoryWA.Models;

namespace InventoryWA.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class InventoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        public InventoryContext() : base("inventoryDBCon")
        {

        }
    }
}