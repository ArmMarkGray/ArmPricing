using System.Collections.Generic;

namespace Pricing.Models
{
    public class CustomerPricingQueryInputModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        public List<ProductModel> Products
        {
            get
            {
                return new List<ProductModel>
                {
                    new ProductModel{ Name = "Product1", Price = 100.0m},
                    new ProductModel{ Name = "Product2", Price = 50.0m},
                    new ProductModel{ Name = "Product3", Price = 25.0m}
                };
            }
        }
    }
}