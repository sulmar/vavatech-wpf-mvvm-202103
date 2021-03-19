using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vavatech.Shop.Models;
using Vavatech.Shop.Models.SearchCriterias;

namespace Vavatech.Shop.IServices
{
    public interface ICustomerService : IEntityService<Customer>
    {
        IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria);
        Task<IEnumerable<Customer>> GetAsync();
        Task<IEnumerable<Customer>> GetAsync(CustomerSearchCriteria searchCriteria);
        Task RemoveAsync(int id);
    }

    public interface ICustomerServiceAsync
    {
        Task<IEnumerable<Customer>> GetAsync();
        Task<IEnumerable<Customer>> GetAsync(CustomerSearchCriteria searchCriteria);
    }
}
