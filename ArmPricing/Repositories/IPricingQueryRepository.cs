using Pricing.Domain;

namespace Pricing.Repositories
{
    public interface IPricingQueryRepository
    {
        void RegisterPricingQuery(PricingQuery pricingQuery);
    }
}