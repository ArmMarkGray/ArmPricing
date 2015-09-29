using System.Web.Mvc;
using Pricing.Domain;
using Pricing.Mappers;
using Pricing.Models;
using Pricing.Services;

namespace Pricing.Controllers
{
    public class PricingQueryController : Controller
    {
        private readonly IPricingQueryRepository _pricingQueryRepository;
        private readonly IEmailingService _emailingServiceMock;
        private readonly ICustomerPricingQueryEngine _customerMapper;

        public PricingQueryController(IPricingQueryRepository pricingQueryRepository, IEmailingService emailingServiceMock, ICustomerPricingQueryEngine customerMapper)
        {
            _pricingQueryRepository = pricingQueryRepository;
            _emailingServiceMock = emailingServiceMock;
            _customerMapper = customerMapper;
        }


        [HttpPost]
        public ActionResult Register(CustomerPricingQueryModel customerPricingQueryModel)
        {
            var pricingQuery = _customerMapper.GenerateQuery(customerPricingQueryModel);
            _pricingQueryRepository.RegisterPricingQuery(pricingQuery);
            _emailingServiceMock.SendEmailToTheSalesTeam(pricingQuery);
            return View("ThankYou");
        }
    }
}
