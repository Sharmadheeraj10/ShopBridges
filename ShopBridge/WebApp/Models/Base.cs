using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{

    /// <summary>
    /// Basic columns to be inserted inside database for evenry column
    /// User_Id: Entered User Id
    /// Is_Active: Item is active or Not in the database
    /// </summary>
    public class BaseClass
    {
        public int User_Id { get; set; }
        public DateTime Entry_date { get; set; }
        public DateTime? Modify_date { get; set; }
        public Boolean Is_Active { get; set; }
    }
}