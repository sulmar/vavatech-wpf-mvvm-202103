using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.Shop.Fakers;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;

namespace Vavatech.Shop.FakeServices
{
    public class DbCustomerService
    {
        private readonly ICollection<Customer> customers;

        // TODO: refactor
        public DbCustomerService()
            : this(new CustomerFaker())
        {

        }

        public DbCustomerService(Faker<Customer> faker)
        {
            customers = faker.Generate(100);
        }

        public void Add(Customer entity)
        {
            customers.Add(entity);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            customers.Remove(Get(id));
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

    }

    public class FakeCustomerService : ICustomerService
    {
        private readonly ICollection<Customer> customers;      

        public FakeCustomerService(Faker<Customer> faker)
        {
            customers = faker.Generate(10);
        }

        public void Add(Customer entity)
        {
            customers.Add(entity);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            return customers.SingleOrDefault(c => c.Id == id);
        }

        public void Remove(int id)
        {
            customers.Remove(Get(id));
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Search(string pattern)
        {

        }
    }
}
