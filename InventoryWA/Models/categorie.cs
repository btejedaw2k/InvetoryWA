using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryWA.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Nombre { get; set; }

        //Icluding foreign table
        public virtual ICollection<Product> Product { get; set; }
        
    }
}