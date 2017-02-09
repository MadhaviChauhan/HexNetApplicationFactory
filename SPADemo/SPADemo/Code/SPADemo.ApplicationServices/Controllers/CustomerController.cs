using SPADemo.BusinessEntities;
using SPADemo.BusinessServices.Interface;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SPADemo.ApplicationServices.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CustomerController : ApiController
    {
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [ResponseType(typeof(CustomerEntity))]
        public IHttpActionResult GetCustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            return Ok((customer) as CustomerEntity);
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            return (_customerService.GetCustomers()) as IEnumerable<CustomerEntity>;
        }

        [HttpGet]
        [Route("api/Customer/CustomerByFilter/{filterObject?}/{sortObject?}")]
        public IEnumerable<CustomerEntity> GetCustomersByFilter(string filterObject, string sortObject)
        {
            return (_customerService.GetCustomersByFilter(filterObject, sortObject)) as IEnumerable<CustomerEntity>;
        }

        [HttpPost]
        [HttpPut]
        public void SaveCustomer(CustomerEntity customer)
        {

            _customerService.SaveCustomer(customer);

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
        }
    }
}
