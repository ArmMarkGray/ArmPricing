using Pricing.Models;

namespace Pricing.Mappers
{
    public interface ICustomerPricingQueryEngine
    {
        void GenerateQuery(CustomerPricingQueryModel customerPricingQueryModel);
    }
}