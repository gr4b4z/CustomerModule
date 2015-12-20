using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerTask.Base;
using CustomerTask.Base.Model;
using CustomerTask.Infrastructure.Static;
using CustomerTask.Models;

namespace CustomerTask.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerRepository _repository;

        //remove below when IoC
        public CustomerController()
        {
            _repository = new CustomerRepository();
        }

        static CustomerController()
        {
            AutoMapper.Mapper.CreateMap<AddressDto, Address>();
            AutoMapper.Mapper.CreateMap<Address, AddressDto>();

            AutoMapper.Mapper.CreateMap<CustomerDto, Customer>();
            AutoMapper.Mapper.CreateMap<Customer, CustomerDto>();
        }
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CustomerDto> Get()
        {
            return AutoMapper.Mapper.Map<CustomerDto[]>(_repository.GetAll());
        }

        // GET api/values/5
        public CustomerDto Get(int id)
        {
            return AutoMapper.Mapper.Map<CustomerDto>(_repository.Get(id));
        }

        // POST api/values
        public CustomerDto Post(CustomerDto customer)
        {
            var cust = AutoMapper.Mapper.Map<Customer>(customer);
            _repository.Add(cust);
            _repository.Commit();

          return    AutoMapper.Mapper.Map<CustomerDto>(_repository.Get(cust.Id));

        }

        // PUT api/values/5
        public void Put(int id, CustomerDto customer)
        {
            var cust = _repository.Get(customer.Id);
            AutoMapper.Mapper.Map(customer, cust);

            _repository.Add(cust);
            _repository.Commit();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            var cust = _repository.Get(id);
            _repository.Delete(cust);
            _repository.Commit();
        }
    }
}
