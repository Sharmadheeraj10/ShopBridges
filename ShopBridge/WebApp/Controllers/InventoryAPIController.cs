using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class InventoryAPIController : ApiController
    {
        // GET api/<controller>
        private readonly IInventoryService _inventoryRepository;
        private readonly IExceptionService _IException;
        ErrorLog error = new ErrorLog();
        public InventoryAPIController(IInventoryService repository, IExceptionService Exp)
        {
            //_logger = logger;
            _inventoryRepository = repository;
            _IException = Exp;
           
        }
        public IHttpActionResult Get()
        {
           
            try
            {
                var Data = _inventoryRepository.getInventoryItem().Select(i => new
                {
                    Id = i.Id,
                    item_name = i.Name,
                    Qty = i.Quantity,
                    Description = i.Description,
                    price = Convert.ToDouble(i.Price) * i.Quantity,
                    deleted = i.Is_Active ? "Enabled" : "Disabled",
                    InStock = i.Quantity - i.consumed == 0 ? "Out Of Stock" : "In Stock",
                    Entry_Date = Convert.ToDateTime(i.Entry_date).ToString("MMM dd, yyyy hh:ss tt"),
                    SortingDate = Convert.ToDateTime(i.Entry_date).ToString("yyyyMMddhhsstt")
                }).ToList();
                return Json(Data);
            }
            catch(Exception ex)
            {
                error.ErrorDetails = ex.Message;
                _IException.AddException(error);
                return Json("Error Encountered");
            }
           
            
            
        }

       
        // GET api/<controller>/5
        public IHttpActionResult Get(int Id)
        {
            try
            {
                return Json(_inventoryRepository.GetItemById(Id));
            } 
            catch(Exception ex)
            {
                error.ErrorDetails = ex.Message;
                _IException.AddException(error);
                return Json("Error Encountered");
            }
            
        }

        // POST api/<controller>
        public IHttpActionResult Post(Inventory inventoryItem)
        {
            try
            {
                if (inventoryItem.Id > 0)
                {
                    return Json(_inventoryRepository.UpdateItem(inventoryItem));

                }
                else
                {
                    return Json(_inventoryRepository.AddRecord(inventoryItem));

                }
            }
            catch (Exception ex)
            {
                error.ErrorDetails = ex.Message;
                _IException.AddException(error);
                return Json("Error Encountered");
            }

            
        }
        // DELETE api/<controller>/5
        
        
        public IHttpActionResult Delete(int id)
        {
            try
            {
                return Json(_inventoryRepository.RemoveItem(id));
            }
            catch (Exception ex)
            {
                error.ErrorDetails = ex.Message;
                _IException.AddException(error);
                return Json("Error Encountered");
            }
           
        }
    }
}