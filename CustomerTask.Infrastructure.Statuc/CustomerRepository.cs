using System;
using System.Collections.Generic;
using System.Linq;
using CustomerTask.Base;
using CustomerTask.Base.Model;

namespace CustomerTask.Infrastructure.Static
{
   public class CustomerRepository: ICustomerRepository
    {
        public static List<Customer> Customer = new List<Customer>()
        {
            new Customer()
            {
                Phone = "+48503665689",
                Surname = "Kowalski",
                Id = 1,
                Address = new Address()
                {
                    Id = 1,
                    City = "Kraków",
                    PostalCode = "53-568",
                    Street = "Kowalskiego 12"
                }
            }, new Customer()
            {
                Phone = "+48545689",
                Surname = "Romczyk",
                Id = 2,
                Address = new Address()
                {
                    Id = 2,
                    City = "Kraków",
                    PostalCode = "00-568",
                    Street = "Krowowdrza 11"
                }
            }, new Customer()
            {
                Phone = "+48503665666",
                Surname = "Nowak",
                Id = 3,
                Address = new Address()
                {
                    Id =3,
                    City = "Kraków",
                    PostalCode = "53-868",
                    Street = "Iwańska 12"
                }
            }
        };

       public Customer Get(int id)
       {
           return Customer.Single(e => e.Id == id);

       }

       public void Update(Customer entity)
       {
           var idx = Customer.IndexOf(entity);
           Customer[idx] = entity;
       }

       public int Add(Customer entity)
        {
            entity.Id = Customer.Count + 10;

            Customer.Add(entity);
           return entity.Id;
       }


       public void Delete(Customer entity)
       {
             Customer.Remove(entity);
        }

       public void Commit()
       {
       }

       IEnumerable<Customer> IRepository<Customer>.GetAll()
        {
            return Customer;
        }
    }
}
