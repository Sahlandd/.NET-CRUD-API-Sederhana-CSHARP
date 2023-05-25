using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Sederhana.Models;

namespace API_Sederhana.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public static List<Customer> listCustomer = new List<Customer>
        {
         new Customer
         {
             customerId = 1,
             customerName = "Andi",
             customerAddress = "Jakarta",
             customerPhoneNumber = "12345",
         },

         new Customer
         {
             customerId = 2,
             customerName = "Bandi",
             customerAddress = "Tangerang",
             customerPhoneNumber = "12345678",
         }

        };

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> getAllCustomer()
        {
            return Ok(listCustomer);
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<List<Customer>>> getCustomerById(int customerId)
        {
            var customer = listCustomer.Find(x => x.customerId == customerId);
            if (customer is null)
                return NotFound("does't exist");
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> addCustomer(Customer addCustomer)
        {
            listCustomer.Add(addCustomer);
            return Ok(listCustomer);
        }

        [HttpPut("{customerId}")]
        public async Task<ActionResult<List<Customer>>> updateById(int customerId, Customer requestUpdate)
        {
            var customer = listCustomer.Find(x => x.customerId == customerId);
            if (customer is null)
                return NotFound("does't exist");
            customer.customerName = requestUpdate.customerName;
            customer.customerAddress = requestUpdate.customerAddress;
            customer.customerPhoneNumber = requestUpdate.customerPhoneNumber;
            return Ok(listCustomer);

        }

        [HttpDelete("{customerId}")]
        public async Task<ActionResult<List<Customer>>> deleteById(int customerId)
        {
            var customer = listCustomer.Find(x => x.customerId == customerId);
            if (customer is null)
                return NotFound("does't exist");
            listCustomer.Remove(customer);
            return Ok(listCustomer);

        }


    }
}
