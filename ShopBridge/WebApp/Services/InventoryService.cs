using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Services
{
    public class InventoryService : IInventoryService
    {
        private InventoryContext _context;
        /// <summary>
        /// CTOR for Initialize DB Context Servce
        /// </summary>
        /// <param name="context"></param>
        public InventoryService(InventoryContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Adding REcord in database
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        string IInventoryService.AddRecord(Inventory item)
        {
            item.Entry_date = DateTime.Now;
            _context.Inventory.Add(item);
            _context.SaveChanges();
            return "Okay";
        }
        /// <summary>
        /// List OF Inventory Items
        /// </summary>
        /// <returns></returns>
        IList<Inventory> IInventoryService.getInventoryItem()
        {
            return _context.Inventory.OrderBy(i => i.Name).ToList();
        }
        
        /// <summary>
        /// Get Inventory by Items Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Inventory IInventoryService.GetItemById(int Id)
        {
            return _context.Inventory.Where(i => i.Id == Id).FirstOrDefault();
        }


        /// <summary>
        /// Delete Item From Inventory System
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        string IInventoryService.RemoveItem(int Id)
        {
            Inventory itemtoDelete = _context.Inventory.Where(i => i.Id == Id).FirstOrDefault();
            _context.Inventory.Remove(itemtoDelete);
            _context.SaveChanges();
            return "Okay";
        }

        /// <summary>
        /// Update Inventory Items
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        string IInventoryService.UpdateItem(Inventory inventory)
        {
            Inventory ItemtoUpdate = _context.Inventory.Where(i => i.Id == inventory.Id).FirstOrDefault();
            ItemtoUpdate.Name = inventory.Name;
            ItemtoUpdate.Description = inventory.Description;
            ItemtoUpdate.Quantity = inventory.Quantity;
           
            ItemtoUpdate.Price = inventory.Price;
            ItemtoUpdate.Is_Active = inventory.Is_Active;
            ItemtoUpdate.User_Id = 1;
            ItemtoUpdate.Modify_date = DateTime.Now;
            _context.SaveChanges();
            return "Okay"; ;

        }


    }
}