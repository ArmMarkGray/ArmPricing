using Pricing.Domain;

namespace Pricing.Services
{
    public interface IEmailingService
    {
        void SendEmailToTheSalesTeam(PricingQuery pricingQuery);
    }
}