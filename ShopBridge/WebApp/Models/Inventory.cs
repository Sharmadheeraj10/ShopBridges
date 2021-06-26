using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    /// <summary>
    /// Inventory Items to be saved inside the database
    /// </summary>
    public class Inventory : BaseClass
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
        public int consumed { get; set; }
    }



    
   

}