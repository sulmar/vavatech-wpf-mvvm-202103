using Bogus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vavatech.Shop.IServices;
using Vavatech.Shop.Models;
using Vavatech.Shop.Models.SearchCriterias;

namespace Vavatech.Shop.FakeServices
{

    public class FakeCustomerService : FakeEntityService<Customer>, ICustomerService
    {
        public FakeCustomerService(Faker<Customer> faker) : base(faker)
        {
        }

        public override IEnumerable<Customer> Get()
        {
            // Task task = Task.Run(action)  - Task task = Task.Factory.StartNew(action)

            // Thread.Sleep(TimeSpan.FromSeconds(2));

            return base.Get();
        }

        public IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria)
        {
            IQueryable<Customer> customers = entities.AsQueryable();

            if (!string.IsNullOrEmpty(searchCriteria.FirstName))
            {
                customers = customers.Where(c => c.FirstName.Contains(searchCriteria.FirstName));
            }

            if (!string.IsNullOrEmpty(searchCriteria.LastName))
            {
                customers = customers.Where(c => c.LastName.Contains(searchCriteria.LastName));
            }

            if (searchCriteria.Credit.CreditAmountFrom.HasValue)
            {
                customers = customers.Where(c => c.CreditAmount >= searchCriteria.Credit.CreditAmountFrom);
            }

            if (searchCriteria.Credit.CreditAmountTo.HasValue)
            {
                customers = customers.Where(c => c.CreditAmount <= searchCriteria.Credit.CreditAmountTo);
            }

            return customers.ToList();


        }

        public Task<IEnumerable<Customer>> GetAsync()
        {
            return Task.Run(() => Get());
        }

        public Task<IEnumerable<Customer>> GetAsync(CustomerSearchCriteria searchCriteria)
        {
            return Task.FromResult(Get(searchCriteria));
        }

        public override void Remove(int id)
        {
            Customer customer = Get(id);
            customer.IsRemoved = true;
        }

        public async Task RemoveAsync(int id)
        {
            Remove(id);

            Trace.WriteLine($"Remove {id}");

            await Task.Delay(TimeSpan.FromSeconds(3));



            // return Task.CompletedTask;
        }
    }
}
