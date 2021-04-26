namespace Vavatech.Shop.Models.SearchCriterias
{
    public class EmployeeSearchCriteria : BaseSearchCriteria
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressSearchCriteria HomeAddress { get; set; }
        public AddressSearchCriteria WorkAddress { get; set; }

        public EmployeeSearchCriteria()
        {
            HomeAddress = new AddressSearchCriteria();
            WorkAddress = new AddressSearchCriteria();
        }
    }
}
