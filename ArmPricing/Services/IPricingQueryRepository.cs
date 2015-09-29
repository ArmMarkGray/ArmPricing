using Pricing.Domain;

namespace Pricing.Services
{
    public interface IPricingQueryRepository
    {
        void RegisterPricingQuery(PricingQuery pricingQuery);
    }
}