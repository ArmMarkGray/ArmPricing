using Pricing.Domain;
using Pricing.Models;

namespace Pricing.Mappers
{
    public interface ICustomerPricingQueryEngine
    {
        PricingQuery GenerateQuery(CustomerPricingQueryModel customerPricingQueryModel);
    }
}