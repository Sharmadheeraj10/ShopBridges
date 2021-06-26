using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Services
{
    //Property API Methods
    public interface IInventoryService
    {
        string AddRecord(Inventory item);
        /// <summary>
        /// List
        /// </summary>
        /// <returns></returns>
        IList<Inventory> getInventoryItem();
        /// <summary>
        /// Remove
        /// </summary>
        /// <returns></returns>
        string RemoveItem(int Id);
        /// <summary>
        /// Get Item byt Id basically for Updating Prupose
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Inventory GetItemById(int Id);
        /// <summary>
        /// Get Item for Updation Purpose
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        string UpdateItem(Inventory inventory);

    }
}