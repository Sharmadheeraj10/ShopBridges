using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Services
{
    public class ExceptionService : IExceptionService
    {
        private InventoryContext _context;
        public ExceptionService(InventoryContext context)
        {
            _context = context;
        }
        void IExceptionService.AddException(ErrorLog error)
        {
            error.Entry_Date = DateTime.Now;
            _context.ErrorLog.Add(error);
        }
    }
}