using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{

    public class ErrorLog
    {
        [Key]
        public int Id { get; set; }
        public string ErrorDetails { get; set; }

        public DateTime Entry_Date { get; set; }
    }
    
    

}