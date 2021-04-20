using GroceryStoreAPI.Controllers;
using GroceryStoreAPI.Models;
using NUnit.Framework;
using System.Threading.Tasks;

namespace NUnitTests
{
    public class CustomerTest
    {
        CustomerController _controller;
        [SetUp]
        public void Setup()
        {

            _controller = new CustomerController(new GroceryStoreAPI.Models.GroceryStoreContext());
            
        }

        [Test]
        public async Task Get()
        {
            var result = _controller.Get();
            Assert.IsTrue(result.Count > 0, "Unit Test Failed");
        }

        [Test]
        public async Task GetById()
        {
            var result = _controller.Get(1);
            Assert.IsTrue(result != null, "Unit Test Failed");
        }

        [Test]
        public async Task Post()
        {
            
            Customer c = new Customer 
            { 
                id = 4,
                name="unit test"
            };

            bool result = await _controller.Post(c);

            Assert.IsTrue(!result, "Unit Test Failed");
        }

        [Test]
        public async Task Put()
        {
            Customer c = new Customer
            {
                id = 4,
                name = "unit test update"
            };

            bool result = await _controller.Put(c);

            Assert.IsTrue(!result, "Unit Test Failed");
        }

    }
}