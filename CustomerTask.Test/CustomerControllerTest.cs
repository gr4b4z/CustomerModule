using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerTask.Base;
using CustomerTask.Base.Model;
using CustomerTask.Models;
using CustomerTask.Web.Controllers;
using NSubstitute;
using Xunit;

namespace CustomerTask.Test
{
    public class CustomerControllerTest
    {
        [Fact]
        public void can_add_full_customer()
        {
            var customerRepo = NSubstitute.Substitute.For<ICustomerRepository>();
            var customerController = new CustomerController(customerRepo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            customerController.Post(new CustomerDto()
            {
                Phone = "123456789",
                Surname = "Kowalski",
                Address = new AddressDto()
                {
                    City = "Warszawa",
                    PostalCode = "22-235",
                    Street = "Gliw 34"

                }
            });

            customerRepo.Received().Add(Arg.Is<Customer>(c => c.Phone == "123456789" && c.Surname == "Kowalski" && c.Address.City == "Warszawa"));
            customerRepo.Received().Commit();
        }

        [Fact]
        public void model_state_is_checked_after_post()
        {
            var customerRepo = NSubstitute.Substitute.For<ICustomerRepository>();
            var customerController = new CustomerController(customerRepo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            customerController.ModelState.AddModelError("err", "err");
            var response = customerController.Post(new CustomerDto()
            {
                Phone = "12345679",
                Surname = "Kowalski",
                Address = new AddressDto()
                {
                    City = "Warszawa",
                    PostalCode = "22-235",
                    Street = "Gliw 34"

                }
            });

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public void model_state_is_checked_after_put()
        {
            var customerRepo = NSubstitute.Substitute.For<ICustomerRepository>();
            var customerController = new CustomerController(customerRepo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            customerController.ModelState.AddModelError("err", "err");
            var response = customerController.Put(2, new CustomerDto()
            {
                Phone = "12345679",
                Surname = "Kowalski",
                Address = new AddressDto()
                {
                    City = "Warszawa",
                    PostalCode = "22-235",
                    Street = "Gliw 34"

                }
            });

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public void can_delete()
        {
            var customerRepo = NSubstitute.Substitute.For<ICustomerRepository>();
            customerRepo.Get(2).Returns(new Customer() { Id = 2});
            var customerController = new CustomerController(customerRepo)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            var response = customerController.Delete(2);

            customerRepo.Received().Delete(Arg.Is<Customer>(c => c.Id==2));
            customerRepo.Received().Commit();
            
        }
    }
}
