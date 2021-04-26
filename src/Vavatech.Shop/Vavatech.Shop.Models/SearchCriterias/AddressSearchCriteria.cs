namespace Vavatech.Shop.Models.SearchCriterias
{
    public class AddressSearchCriteria : BaseSearchCriteria
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
