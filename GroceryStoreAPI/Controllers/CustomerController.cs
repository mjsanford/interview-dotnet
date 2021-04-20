using GroceryStoreAPI.Models;
using JsonFlatFileDataStore;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Controllers
{
    [ApiController]
    [Route("api/ApiCustomer")]
    public class CustomerController : ControllerBase
    {
        Logger Logger = LogManager.GetLogger("GroceryStoreAPI.Controllers.CustomerController");
        GroceryStoreContext _context;

        public DataStore store;

        public CustomerController(GroceryStoreContext context) {
            _context = context;
            store = new DataStore("database.json");
        }

        private string GetRelativePath(string v)
        {
            throw new NotImplementedException();
        }

        public List<Customer> Get()
        {
            List<Customer> result = new List<Customer>();
            try
            {
                result = store.GetCollection<Customer>("customers").AsQueryable().ToList();

            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return result;
        }
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            Customer result = null;
            try
            {
                result = store.GetCollection<Customer>("customers").AsQueryable().FirstOrDefault(c => c.id == id);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return result;
        }

        [HttpPost]
        public async Task<bool> Post([FromBody] Customer value)
        {
            bool result = false;
            try
            {
                var collection = store.GetCollection<Customer>("customers");
                result = await collection.InsertOneAsync(value);
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return result;
        }

        [HttpPut]       
        public async Task<bool> Put([FromBody] Customer value)
        {
            bool result = false;
            try
            {
                var collection = store.GetCollection<Customer>("customers");
                result = await collection.UpdateOneAsync(e => e.id == value.id, value);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
            }
            return result;

        }


    }
}
