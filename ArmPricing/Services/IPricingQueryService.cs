using Pricing.Domain;

namespace Pricing.Services
{
    public interface IPricingQueryService
    {
        void RegisterPricingQuery(PricingQuery pricingQuery);
    }
}