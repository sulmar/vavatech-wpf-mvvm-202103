using System;
using System.Collections.Generic;
using Vavatech.Shop.Models;
using Vavatech.Shop.Models.SearchCriterias;

namespace Vavatech.Shop.IServices
{
    public interface ICustomerService : IEntityService<Customer>
    {
        IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria);
    }
}
