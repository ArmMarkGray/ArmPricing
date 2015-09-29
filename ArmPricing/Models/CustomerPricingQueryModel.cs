using System.Collections.Generic;

namespace Pricing.Models
{
    public class CustomerPricingQueryModel
    {
        public CustomerPricingQueryModel()
        {
            Products = new List<ProductModel>();
        }

        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}